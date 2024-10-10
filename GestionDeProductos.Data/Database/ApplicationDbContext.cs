using GestionDeProductos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductos.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}
