using System;
using System.Net;
using System.Threading.Tasks;
using Api.Integration.Test;
using API.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace API.Integration.Test.Usuario
{
    public class CrudUsuarioTestes : BaseIntegration
    {
        public string _name { get; set; }
        public string _email { get; set; }

        [Fact]
        public async Task Quando_Criado_Usuario()
        {
            await AdicionarToken();

            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();

            var request = new UserDtoCreate()
            {
                Email = _email,
                Nome = _name
            };

            var response = await PostJsonAsync(request, $"{HostApi}users",Client);
            var resultString = await response.Content.ReadAsStringAsync();
            var resultJson = JsonConvert.DeserializeObject<UserDtoCreateResult>(resultString);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, resultJson.Nome);
            Assert.Equal(_email, resultJson.Email);
            Assert.True(resultJson.Id != default(Guid));
        }
    }
}
