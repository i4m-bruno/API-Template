using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos.User
{
    public class UserDtoCreate
    {  
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(40, ErrorMessage = "Nome muito longo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(120, ErrorMessage = "Email muito longo")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }
    }
}
