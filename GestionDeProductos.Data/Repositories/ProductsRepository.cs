using Microsoft.EntityFrameworkCore;
using GestionDeProductos.Data.Models;
using GestionDeProductos.Data.Database;
using GestionDeProductos.Data.Repositories;

namespace GestionDeProductos.Data.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext context) : base(context) { }
         

        public async Task<Products?> GetProductById(Guid? id)
        {
            return await Context.Products
                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Products?> GetProductByName(string? name)
        {
            return await Context.Products
                .FirstOrDefaultAsync(c => c.Nombre == name);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await Context.Products
              .ToListAsync();
        }
    }
}
