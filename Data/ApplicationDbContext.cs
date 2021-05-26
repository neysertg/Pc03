using Microsoft.EntityFrameworkCore;
using Pc03.Models;

namespace Pc03.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public ApplicationDbContext(DbContextOptions p) : base (p)
        {
            
        }
    }
}
