using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Shared;

namespace NZWalks.API.Repositories.Shared
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected NZWalksDbContext context;
        public readonly ILogger logger;
        internal DbSet<T> dbSet;

        public GenericRepository(
            NZWalksDbContext context,
            ILogger logger)
        {
            this.context = context;
            this.logger = logger;

            this.dbSet = context.Set<T>();
        }

        public virtual Task<IEnumerable<T>?> GetAllAsync(Query? query)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(Guid id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
