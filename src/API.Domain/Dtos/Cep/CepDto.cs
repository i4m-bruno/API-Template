using System;
using API.Domain.Dtos.UF;

namespace API.Domain.Dtos.Cep
{
    public class CepDto
    {
        public Guid CepId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioDto Municipio { get; set; }
    }
}
