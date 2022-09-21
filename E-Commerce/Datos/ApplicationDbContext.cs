using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {

        }

        public DbSet <Categoria> Categoria{ get; set; }

        public DbSet<TipoAplicacion> TipoAplicacion{ get; set; }
    }
}
