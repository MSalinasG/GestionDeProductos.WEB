using GestionDeProductos.Data.Database;
using GestionDeProductos.Data.Repositories;

namespace GestionDeProductos.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IProductsRepository _productsRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _db = context;
            _productsRepository = new ProductsRepository(_db);
        }

        public IProductsRepository ProductsRepository => _productsRepository;

        public ApplicationDbContext DatabaseContext => _db;

        public async Task Complete()
        {
            await _db.SaveChangesAsync();
        }
    }
}
