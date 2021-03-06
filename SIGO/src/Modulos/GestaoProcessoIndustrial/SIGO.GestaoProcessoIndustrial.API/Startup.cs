using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using SIGO.Bus.EventBus;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.Bus.EventBusRabbitMQ;
using SIGO.Bus.IntegrationEventLogEF.Services;
using SIGO.Domain;
using SIGO.GestaoProcessoIndustrial.API.IntegrationEvents;
using SIGO.GestaoProcessoIndustrial.API.IntegrationEvents.EventHandling;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using SIGO.GestaoProcessoIndustrial.Infra.Context;
using SIGO.GestaoProcessoIndustrial.Infra.Repository;
using SIGO.GestaoProcessoIndustrial.Infra.UnitOfWork;
using SIGO.GestaoProcessoIndustrial.Service;
using SIGO.Infra;
using SIGO.Utils;
using System.Collections.Generic;

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
            var connection = Configuration["ConnectionStrings:GestaoProcessoIndustrialConnection"];

            services.AddDbContext<GestaoProcessoIndustrialDbContext>(options =>
                options.UseMySql(connection)
            );

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Autorizacao.Chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();

            services.AddEventBus(Configuration)
                    .AddIntegrationServices(Configuration)
                    .AddServices()
                    .AddRepositories();

            services.AddScoped<IDapperDbConnection, DapperDbConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Program.AppName, Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Program.AppName);
            });

            ConfigureEventBus(app);
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<NormaCadastradaIntegrationEvent, NormaCadastradaIntegrationEventHandler>();
            eventBus.Subscribe<EstoqueMinimoIntegrationEvent, EstoqueMinimoIntegrationEventHandler>();
            eventBus.Subscribe<RelacaoOrcamentoVendasIntegrationEvent, RelacaoOrcamentoVendasEventHandler>();
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
            services.AddTransient<EstoqueMinimoIntegrationEventHandler>();
            services.AddTransient<RelacaoOrcamentoVendasEventHandler>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
