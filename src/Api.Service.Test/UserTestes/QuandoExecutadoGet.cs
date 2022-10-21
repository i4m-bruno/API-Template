using System;
using System.Threading.Tasks;
using API.Domain.Dtos.User;
using API.Domain.interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.UserTestes
{
    public class QuandoExecutadoGet : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact]
        public async Task Get_Success()
        {
            // Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(UserDto);
            _service = _serviceMock.Object;
            // When
            var result = await _service.Get(UserId);
            // Then
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(result.Nome , Name);
            Assert.Equal(result.Email , Email);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            // Given
             _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult<UserDto>(null));
            _service = _serviceMock.Object;
            // When
            var result = await _service.Get(Guid.NewGuid());
            // Then
            Assert.Null(result);
        }
    }
}
