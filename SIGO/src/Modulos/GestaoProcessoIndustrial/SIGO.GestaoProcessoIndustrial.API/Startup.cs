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
using SIGO.GestaoProcessoIndustrial.API.IntegrationEvents;
using SIGO.GestaoProcessoIndustrial.API.IntegrationEvents.EventHandling;
using SIGO.GestaoProcessoIndustrial.API.IntegrationEvents.Events;
using SIGO.GestaoProcessoIndustrial.Infra.Context;
using SIGO.Utils;

namespace SIGO.GestaoProcessoIndustrial.API
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
                   .AddIntegrationServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
            eventBus.Subscribe<NormaCadastradaIntegrationEvent, NormaCadastradaIntegrationEventHandler>();
        }
    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
            //    sp => (DbConnection c) => new IIntegrationEventLogService(c));

            services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService>();

            services.AddDbContext<GestaoProcessoIndustrialDbContext>(options => options.UseSqlServer("GestaoProcessoIndustrialSqlServer"));

            services.AddTransient<IGestaoProcessoIndustrialIntegrationEventService, GestaoProcessoIndustrialIntegrationEventService>();

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
    }
}