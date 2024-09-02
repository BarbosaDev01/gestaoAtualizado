using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.acao> acao { get; set; } = default!;
        public DbSet<WebApplication1.Models.anexo> anexo { get; set; } = default!;
        public DbSet<WebApplication1.Models.projeto> projeto { get; set; } = default!;
        public DbSet<WebApplication1.Models.usuario> usuario { get; set; } = default!;
    }
}
