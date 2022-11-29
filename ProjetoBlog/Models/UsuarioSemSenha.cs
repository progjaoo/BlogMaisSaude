using System.ComponentModel.DataAnnotations;
using ProjetoBlog.Enums;

namespace ProjetoBlog.Models
{
    public class UsuarioSemSenha
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o nome do Usuário")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite o nome do Login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o Email do Usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe o Perfil do Usuário")]
        public PerfilEnum? Perfil { get; set; }

    }
}
