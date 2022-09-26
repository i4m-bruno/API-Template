using System;
using API.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                                    "v1", new OpenApiInfo 
                                    { 
                                        Title = "API Template", 
                                        Version = "v1",
                                        Description = "Template para projetos de API, com arquitetura DDD e alguns patterns", 
                                        Contact = new OpenApiContact
                                        {
                                            Name = "Bruno Rodrigues Dos Santos Cardoso",
                                            Email = "ossbruno@outlook.com",
                                            Url = new Uri("https://www.linkedin.com/in/bruno-rodrigues-807a001b1/")
                                        }
                                    }
                            );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => 
                                    {
                                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Template");
                                        c.RoutePrefix = string.Empty;
                                    }
                                );
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
