using System;
using System.Threading.Tasks;
using API.Application.Controllers;
using API.Domain.interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Application.Test.Usuario
{
    public class DeleteBadRequest
    {
        private UsersController _controller;

        [Fact]
        public async Task Usuario_Deletado_BadRequest()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("id","id inválido");

            var result = await _controller.DeleteUser(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
