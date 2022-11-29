using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProjetoBlog.Data;
using ProjetoBlog.Models;

namespace ProjetoBlog.Repositorios
{
    public class RepositoryBlog
    {
        private bool RecebeuContexto = false;
        private BlogContext odb;

        public RepositoryBlog()
        {
            odb = new BlogContext();
        }

        public RepositoryBlog(BlogContext _odb)
        {
            odb = _odb;
            RecebeuContexto = true;
        }
        public List<Post> ListarTodos()
        {
            return (from p in odb.Post select p).OrderByDescending(a => a.DataPost).ToList();
        }
        public Post Selecionar(int ID)
        {
            return (from p in odb.Post where p.Id == ID select p).FirstOrDefault();
        }

        public void Incluir(Post oPost)
        {
            odb.Entry(oPost).State = EntityState.Added;
            odb.SaveChanges();
        }
        public void Alterar(Post oPost)
        {
            odb.Post.Attach(oPost);
            odb.Entry(oPost).State = EntityState.Modified;
            odb.SaveChanges();
        }
        public void Excluir(int ID)
        {
            Post oPost = (from p in odb.Post where p.Id == ID select p).FirstOrDefault();
            odb.Entry(oPost).State = EntityState.Deleted;
            odb.SaveChanges();
        }
        public void Excluir(Post oPost)
        {
            odb.Entry(oPost).State = EntityState.Deleted;
            odb.SaveChanges();
        }
    }
}