using System;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos.UF
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome do municícpio é obrigatório")]
        [StringLength(60,ErrorMessage = "Tamanho máximo para nome de município => {1} caracteres")]
        public string Nome { get; set; }

        [Range(0,int.MaxValue,ErrorMessage = "Código ibge inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "UfId é um campo obrigatório")]
        public Guid UfId { get; set; }

    }
}
