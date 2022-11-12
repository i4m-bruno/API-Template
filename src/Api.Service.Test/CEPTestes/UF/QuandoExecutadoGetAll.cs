using System.Collections.Generic;
using System.Linq;
using API.Domain.Dtos.UF;
using API.Domain.interfaces.Services.Cep;
using Moq;
using Xunit;

namespace API.Service.Test.CEPTestes.UF
{
    public class QuandoExecutadoGetAll : BaseUF
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact]
        public async void Eh_Possivel_Executar_GetAll()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.ListUfs()).ReturnsAsync(listaUfDto);
            _service = _serviceMock.Object;

            var result = await _service.ListUfs();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var listResult = new List<UfDto>();
             _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.ListUfs()).ReturnsAsync(listResult);
            _service = _serviceMock.Object;

            result = await _service.ListUfs();
            Assert.Empty(result);
        }
    }
}
