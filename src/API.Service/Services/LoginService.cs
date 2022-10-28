using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using API.Domain.Dtos;
using API.Domain.entities;
using API.Domain.interfaces.Services.User;
using API.Domain.repository;
using API.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepo;
        private SigningConfigurations _signingConfig;
        private IConfiguration _config;

        public LoginService(IUserRepository userRepo, SigningConfigurations signingConfig, IConfiguration config)
        {
            _userRepo = userRepo;
            _signingConfig = signingConfig;
            _config = config;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();

            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _userRepo.FindByLogin(user.Email);
                
                if(baseUser == null)
                {
                    return new 
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }

                var identity = new ClaimsIdentity(
                                    new GenericIdentity(baseUser.Email),
                                    new[]
                                    {
                                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                                    });
                
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = DateTime.Now + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                var token = CreateToken(identity,createDate,expirationDate);

                return SuccessResponse(createDate,expirationDate,token,baseUser);
            }

            return null;
        }

        private object CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate)
        {
            var handler = new JwtSecurityTokenHandler();

            var secToken = handler.CreateToken(new SecurityTokenDescriptor{
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfig.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(secToken);

            return token;
        }

        private object SuccessResponse(DateTime createDate, DateTime expirationDate, object token, UserEntity user)
        {
            return new 
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expires = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Nome,
                mail = user.Email,
                message = "Logado com sucesso"
            };
        }
    }
}
