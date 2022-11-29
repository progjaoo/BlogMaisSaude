using ProjetoBlog.Models;

namespace ProjetoBlog.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario sessao);
        void RemoverSessaoDoUsuario();

        Usuario BuscarSessaoDoUsuario();
    }
}
