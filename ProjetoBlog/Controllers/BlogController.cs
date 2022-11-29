using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBlog.Filters;
using ProjetoBlog.Models;
using ProjetoBlog.Repositorios;

namespace BlogProjetoInt.Controllers
{
    public class BlogController : Controller
    {
        
        // GET: BlogController
        public ActionResult Index()
        {
            RepositoryBlog orepository = new RepositoryBlog();
            List<Post> oLista = orepository.ListarTodos();
            return View(oLista);
        }
        [PageRestritaAdmin]

        // GET: BlogController/Details/5
        public ActionResult Details(int ID)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            Post oPost = orepository.Selecionar(ID);
            return View(oPost);
        }
        public ActionResult PostCompleto(int ID)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            Post oPost = orepository.Selecionar(ID);
            return View(oPost);
        }
        [PageRestritaAdmin]
        // GET: BlogController/Create
        public ActionResult Create()
        {
            Post oPost = new Post();
            return View(oPost);
        }

        
        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post oPost)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            oPost.DataPost = DateTime.Now;
            var video = oPost.Video;
            if (video != null)
            {
                video = video.Replace("watch?v=", "embed/");
            }

            oPost.Video = video;
            orepository.Incluir(oPost);
            return View("Index", orepository.ListarTodos());
        }
        [PageRestritaAdmin]

        // GET: BlogController/Edit/5
        public ActionResult Edit(int ID)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            Post oPost = orepository.Selecionar(ID);
            return View(oPost);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post oPost)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            var video = oPost.Video;
            if (video != null)
            {
                video = video.Replace("watch?v=", "embed/");
            }

            oPost.Video = video;
            orepository.Alterar(oPost);
            return View(oPost);
        }
        [PageRestritaAdmin]

        // GET: BlogController/Delete/5
        public ActionResult Delete(int ID)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            Post oPost = orepository.Selecionar(ID);
            return View(oPost);
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID, IFormCollection collection)
        {
            RepositoryBlog orepository = new RepositoryBlog();
            orepository.Excluir(ID);
            return View("Index", orepository.ListarTodos());
        }
    }
}
