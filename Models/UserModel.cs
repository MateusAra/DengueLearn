using System.ComponentModel.DataAnnotations;

namespace DengueLearn.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Digite o email.")]
        [EmailAddress(ErrorMessage = "Infome um email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Digite o nome de usuário.")]
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
