using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo de email {1} caracteres")]
        public string Email { get; set; }
    }
}
