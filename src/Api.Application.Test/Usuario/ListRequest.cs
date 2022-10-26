using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Controllers;
using API.Domain.Dtos.User;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario
{
    public class List
    {
        private UsersController _controller;

        [Fact]
        public async Task List_Sucesso()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.List()).ReturnsAsync(
                new List<UserDto>()
                {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.First(),
                        Email = Faker.Internet.Email(),
                    },
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.First(),
                        Email = Faker.Internet.Email(),
                    }
                }
 
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.List();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<UserDto>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() > 1);
        }
    }
}
