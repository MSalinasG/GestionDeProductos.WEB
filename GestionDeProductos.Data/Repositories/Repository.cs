
using GestionDeProductos.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductos.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext contextParam)
        {
            Context = contextParam;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> Get(Guid? id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        } 

        public async Task Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

       
    }
}
