using System.ComponentModel.DataAnnotations;

namespace DengueLearn.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Digite o email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o nome de usuário.")]
        public string UserName { get; set; }
    }
}
