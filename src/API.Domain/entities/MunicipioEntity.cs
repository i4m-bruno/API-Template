using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.entities
{
    public class MunicipioEntity : BaseEntity
    {
        public MunicipioEntity()
        {
            Id = Guid.NewGuid();
        }
        
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        [Required]
        public Guid UfId { get; set; }
        public UfEntity Uf { get; set; }
        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}
