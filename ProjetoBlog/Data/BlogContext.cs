using Microsoft.EntityFrameworkCore;
using ProjetoBlog.Models;

namespace ProjetoBlog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext (DbContextOptions<BlogContext> options) :base(options)
        {
        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=dbbom.ctmomttocofa.us-east-1.rds.amazonaws.com;Initial Catalog=BancoBlog;Encrypt=False;TrustServerCertificate=False;User ID=admin;Password=9y8PfRTNdpKURMu6kIAr");
            }
        }

    }
}
