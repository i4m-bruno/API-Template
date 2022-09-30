using System;
using System.Collections.Generic;
using API.Application.Configs;
using API.CrossCutting.DependencyInjection;
using API.Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
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

            var signingConfig = new SigningConfigurations();
            services.AddSingleton(signingConfig);

            var tokenConfig = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations> // configura servico a partir de appSettings.json
                        (Configuration.GetSection("TokenConfigurations"))
                        .Configure(tokenConfig);

            var bearerConfig = new BearerConfig(services,signingConfig,tokenConfig);
            bearerConfig.AddAuth();            

            services.AddSingleton(tokenConfig);

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
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                    Description = "Entre com o token jwt",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                            }                          
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
