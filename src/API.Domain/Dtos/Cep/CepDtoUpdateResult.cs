using System;

namespace API.Domain.Dtos.Cep
{
    public class CepDtoUpdateResult
    {
        public Guid CepId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
