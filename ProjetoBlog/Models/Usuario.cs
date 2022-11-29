using System.ComponentModel.DataAnnotations;
using ProjetoBlog.Enums;

namespace ProjetoBlog.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome do Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite o Email do Usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Escolha o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        public DateTime DataCadastrado { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
