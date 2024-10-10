namespace GestionDeProductos.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> Get(Guid? id);
        Task Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
