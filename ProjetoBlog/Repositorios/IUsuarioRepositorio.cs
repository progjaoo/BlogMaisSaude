using ProjetoBlog.Models;

namespace ProjetoBlog.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        List<Usuario> BuscarTodos();
        Usuario BuscarPorId(int id);
        Usuario Incluir (Usuario usuario);
        Usuario Alterar(Usuario usuario);
        bool Apagar (int id);
    }
}
