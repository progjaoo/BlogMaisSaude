using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
namespace ProjetoBlog.Models
{
    public class LoginModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Digite o Login")]
        public string Login { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
