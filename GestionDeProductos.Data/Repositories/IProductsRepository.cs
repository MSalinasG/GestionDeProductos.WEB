using GestionDeProductos.Data.Models;
using GestionDeProductos.Data.Repositories;

namespace GestionDeProductos.Data.Repository
{
    public interface IProductsRepository : IRepository<Products>
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products?> GetProductById(Guid? id);

        Task<Products?> GetProductByName(string? name);
    }
}
