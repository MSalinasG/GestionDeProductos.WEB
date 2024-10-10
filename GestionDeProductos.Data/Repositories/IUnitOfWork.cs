using GestionDeProductos.Data.Database;
using GestionDeProductos.Data.Repository;

namespace GestionDeProductos.Data.Repositories
{
    public interface IUnitOfWork
    {
        ApplicationDbContext DatabaseContext { get; }
        IProductsRepository ProductsRepository { get; }
        Task Complete();
    }
}
