using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;
using API.Domain.interfaces.Services.Cep;
using Moq;
using Xunit;

namespace API.Service.Test.CEPTestes.UF
{
    public class QuandoExecutadoGet : BaseUF
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact]
        public async void Eh_Possivel_Executar_Get()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetUf(IdUf)).ReturnsAsync(UfDto);
            _service = _serviceMock.Object;

            var result = await _service.GetUf(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(Nome,result.Nome);

             _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetUf(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _service = _serviceMock.Object;

            result = await _service.GetUf(IdUf);
            Assert.Null(result);
        }
    }
}
