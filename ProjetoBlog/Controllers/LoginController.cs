using Microsoft.AspNetCore.Mvc;
using ProjetoBlog.Helper;
using ProjetoBlog.Models;
using ProjetoBlog.Repositorios;

namespace ProjetoBlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;   
        }

        public IActionResult Index()
        {
            //se usuario ja estiver logado, joga ele para tela home!

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    Usuario usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                    //só redireciona pra home se
                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Usuário ou senha inválido(s). Por Favor, tente novamente";

                    }
                    TempData["MensagemErro"] = $"Usuário ou senha inválido(s). Por Favor, tente novamente"; 
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
