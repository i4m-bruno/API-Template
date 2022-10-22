using System;
using API.Domain.interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.UserTestes
{
    public class QuandoExecutadoDelete : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact]
        public async void Delete_Success()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(Guid.NewGuid());
            Assert.True(result);
        }
        
        [Fact]
        public async void Delete_Failed()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
