using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Dtos.User;
using API.Domain.interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.UserTestes
{
    public class QuandoExecutadoList : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact]
        public async Task List_Success()
        {
            // Given
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.List()).ReturnsAsync(UserDtoList);
            _service = _serviceMock.Object;
            // When
            var result = await _service.List();
            // Then
            Assert.NotNull(result);
            Assert.True(result.Count() == 6);
        }

        [Fact]
        public async Task List_Empty()
        {
            // Given
            var emptyList = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.List()).ReturnsAsync(emptyList);
            _service = _serviceMock.Object;
            // When
            var result = await _service.List();
            // Then
            Assert.Empty(result);
            Assert.True(result.Count() == 0);
        }
    }
}
