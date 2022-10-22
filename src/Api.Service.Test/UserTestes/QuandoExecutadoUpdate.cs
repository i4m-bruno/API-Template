using API.Domain.interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.UserTestes
{
    public class QuandoExecutadoUpdate : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact]
        public async void Update_Success()
        {
            // Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(UserDtoUpdate)).ReturnsAsync(UserDtoUpdateResult);
            _service = _serviceMock.Object;
            // When
            var result = await _service.Put(UserDtoUpdate);
            // Then
            Assert.NotNull(result);
            Assert.Equal(NewName , result.Nome);
            Assert.Equal(NewEmail , result.Email);
        }
    }
}
