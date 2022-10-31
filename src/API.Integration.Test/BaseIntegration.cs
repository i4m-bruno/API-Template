using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.CrossCutting.Mappings;
using API.Data.Context;
using API.Domain.Dtos;
using API.Integration.Test;
using Application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration
    {
        public MyContext MyContext { get; set; }
        public HttpClient Client { get; set; }
        public IMapper Mapper { get; set; }
        public string HostApi { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }

        public BaseIntegration()
        {
            HostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder()
                            .UseEnvironment("Testing")
                            .UseStartup<Startup>();
            var server = new TestServer(builder);

            MyContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            MyContext.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();

            Client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "adm@mail"
            };

            var resultLogin = await PostJsonAsync(loginDto,$"{HostApi}Login",Client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",loginObject.accessToken);

        }

        protected static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, string url, HttpClient client)
        {
            return await client.PostAsync(url,
                                new StringContent(JsonConvert.SerializeObject(dataClass), System.Text.Encoding.UTF8, "application/json" ));
        }

        public void Dispose()
        {
            MyContext.Dispose();
            Client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg => 
                {
                    cfg.AddProfile(new UserModelToEntity());
                    cfg.AddProfile(new UserEntityToDtoProfile());
                    cfg.AddProfile(new UserDtoToModelProfile());
                });
                return config.CreateMapper();
            }

            public void Dispose() {}
        }
}
