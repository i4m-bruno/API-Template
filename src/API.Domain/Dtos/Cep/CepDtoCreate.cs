using System;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "Cep é campo obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        [Required(ErrorMessage = "MunicipioId é campo obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
