using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using SIGO.Bus.EventBus;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBusRabbitMQ;
using SIGO.Bus.IntegrationEventLogEF.Services;
using SIGO.GestaoNormas.API.IntegrationEvents;
using SIGO.GestaoNormas.API.IntegrationEvents.EventHandling;
using SIGO.GestaoNormas.Domain.Interfaces;
using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using SIGO.GestaoNormas.Infra.Connection;
using SIGO.GestaoNormas.Infra.Context;
using SIGO.GestaoNormas.Infra.Repository;
using SIGO.GestaoNormas.Infra.UnitOfWork;
using SIGO.GestaoNormas.Service;
using SIGO.Utils;

namespace SIGO.GestaoNormas.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEventBus(Configuration)
                    .AddIntegrationServices(Configuration)
                    .AddServices()
                    .AddRepositories();

            services.AddScoped<IDapperDbConnection, DapperDbConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<NormaCadastradaIntegrationEvent, NormaCadastradaIntegrationEventHandler>();
        }
    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
            //    sp => (DbConnection c) => new IIntegrationEventLogService(c));

            services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService>();

            services.AddDbContext<GestaoNormasDbContext>(options => options.UseMySql("GestaoNormasSqlServer"));

            services.AddTransient<IGestaoNormasIntegrationEventService, GestaoNormasIntegrationEventService>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = configuration[Configuration.Keys.EventBusConnection],
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(configuration[Configuration.Keys.EventBusUserName]))
                    factory.UserName = configuration[Configuration.Keys.EventBusUserName];

                if (!string.IsNullOrEmpty(configuration[Configuration.Keys.EventBusPassword]))
                    factory.Password = configuration[Configuration.Keys.EventBusPassword];

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration[Configuration.Keys.EventBusRetryCount]))
                    retryCount = int.Parse(configuration[Configuration.Keys.EventBusRetryCount]);

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration[Configuration.Keys.SubscriptionClientName];

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration[Configuration.Keys.EventBusRetryCount]))
                    retryCount = int.Parse(configuration[Configuration.Keys.EventBusRetryCount]);

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddTransient<NormaCadastradaIntegrationEventHandler>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<INormaService, NormaService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INormaRepository, NormaRepository>();

            return services;
        }
    }
}
