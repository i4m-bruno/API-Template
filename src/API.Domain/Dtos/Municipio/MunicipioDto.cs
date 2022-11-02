using System;

namespace API.Domain.Dtos.UF
{
    public class MunicipioDto
    {
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        public UfDto Uf { get; set; }
    }
}
