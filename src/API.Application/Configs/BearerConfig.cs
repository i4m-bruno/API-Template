using System;
using API.Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace API.Application.Configs
{
    public class BearerConfig
    {
        private readonly IServiceCollection _service;
        private readonly SigningConfigurations _signingConfig;
        public BearerConfig(IServiceCollection service, SigningConfigurations signingConfig)
        {
            _service = service;
            _signingConfig = signingConfig;
        }

        public void AddAuth()
        {
            _service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOpt => {
                var paramsOptions = bearerOpt.TokenValidationParameters;
                paramsOptions.IssuerSigningKey = _signingConfig.Key;
                paramsOptions.ValidAudience = Environment.GetEnvironmentVariable("Audience");
                paramsOptions.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");
                paramsOptions.ValidateIssuerSigningKey =  true;
                paramsOptions.ValidateLifetime = true;
                paramsOptions.ClockSkew = TimeSpan.Zero;
            });

            _service.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                                            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                            .RequireAuthenticatedUser().Build());
            });
        }
    }
}
