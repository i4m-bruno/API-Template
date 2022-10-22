using API.Domain.interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.UserTestes
{
    public class QuandoExecutadoCreate : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact]
        public async void Create_Success()
        {
            // Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _service = _serviceMock.Object;
            // When
            var result = await _service.Post(UserDtoCreate);
            // Then
            Assert.NotNull(result);
            Assert.Equal(Name , result.Nome);
            Assert.Equal(Email , result.Email);
        }
    }
}
