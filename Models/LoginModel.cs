using System.ComponentModel.DataAnnotations;

namespace DengueLearn.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o email.")]
        [EmailAddress(ErrorMessage = "Digite um email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha.")]
        public string Password { get; set; }
    }
}
