namespace GroceryShopAPI.Data.Repositories
{
    using GroceryShopAPI.Data.Entities;

    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> Save();
    }
}
