using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace SIGO.ApiGateway
{
    public class Startup
    {
        private IConfiguration configuration;
        private readonly string SIGO_Front = "SIGO_Front";

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

     
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(name: SIGO_Front,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200", "https://sigoweb.azurewebsites.net/")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
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

            app.UseCors(SIGO_Front);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => {

                    await context.Response.WriteAsync("API GATEWAY FUNCIONANDO");
                });
            });

            app.UseOcelot().Wait();
        }
    }
}
