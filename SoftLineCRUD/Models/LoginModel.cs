using System.ComponentModel.DataAnnotations;

namespace SoftLineCRUD.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite um login válido.")]
        public required string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha.")]
        public required string Senha { get; set; }
    }
}
