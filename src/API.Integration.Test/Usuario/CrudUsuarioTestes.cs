using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public async Task Crud_Usuario()
        {
            await AdicionarToken();

            //post

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

            // list

            response = await Client.GetAsync($"{HostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var listJsonResult = await response.Content.ReadAsStringAsync();
            var listJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(listJsonResult);
            Assert.NotNull(listJson);
            Assert.True(listJson.Count() > 0);
            Assert.True(listJson.Where(r => r.Id == resultJson.Id).Count() > 0);

            // update

            var updateDto = new UserDtoUpdate()
            {
                Id = resultJson.Id,
                Email = Faker.Internet.Email(),
                Nome = Faker.Name.FullName()
            };

            var stringRequest = new StringContent(JsonConvert.SerializeObject(updateDto),Encoding.UTF8,"application/json");
            response = await Client.PutAsync($"{HostApi}users",stringRequest);
            var updateStringResult = await response.Content.ReadAsStringAsync();
            var updateJsonResult = JsonConvert.DeserializeObject<UserDtoUpdateResult>(updateStringResult);

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.NotEqual(_name,updateJsonResult.Nome);
            Assert.NotEqual(_email,updateJsonResult.Email);

            // get by id

            response = await Client.GetAsync($"{HostApi}users/{updateJsonResult.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var getStringresult = await response.Content.ReadAsStringAsync();
            var getJsonResult = JsonConvert.DeserializeObject<UserDto>(getStringresult);

            Assert.NotNull(getJsonResult);
            Assert.Equal(getJsonResult.Nome,updateJsonResult.Nome);
            Assert.Equal(getJsonResult.Email,updateJsonResult.Email);

            // delete

            response = await Client.DeleteAsync($"{HostApi}users/{updateJsonResult.Id}");
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

            response = await Client.GetAsync($"{HostApi}users/{updateJsonResult.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
