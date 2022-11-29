using ProjetoBlog.Data;
using ProjetoBlog.Models;

namespace ProjetoBlog.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BlogContext _context;

        public UsuarioRepositorio(BlogContext context)
        {
            _context = context;
        }

        public Usuario Alterar(Usuario usuario)
        {
            Usuario usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuario");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DataAtualizacao = DateTime.Now;
            usuarioDB.Perfil = usuario.Perfil;  
            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }
        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public bool Apagar(int id)
        {
            Usuario usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro exclusão do Usuário!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

        public Usuario Incluir(Usuario usuario)
        {
            usuario.DataCadastrado = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
}
