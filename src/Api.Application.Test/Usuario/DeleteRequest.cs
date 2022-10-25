using System;
using System.Threading.Tasks;
using API.Application.Controllers;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Application.Test.Usuario
{
    public class DeleteRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task Usuario_Deletado_Sucesso()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.DeleteUser(default(Guid));
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}
