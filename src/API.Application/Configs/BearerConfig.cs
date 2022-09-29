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
        private readonly TokenConfigurations _tokenConfig;
        public BearerConfig(IServiceCollection service, SigningConfigurations signingConfig, TokenConfigurations tokenConfig)
        {
            _service = service;
            _signingConfig = signingConfig;
            _tokenConfig = tokenConfig;
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
                paramsOptions.ValidAudience = _tokenConfig.Audience;
                paramsOptions.ValidIssuer = _tokenConfig.Issuer;
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
