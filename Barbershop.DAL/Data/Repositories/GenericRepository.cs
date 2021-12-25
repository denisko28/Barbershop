using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Exceptions;
using Barbershop.DAL.Context;
using Barbershop.DAL.Interfaces.Repositories;

namespace Barbershop.DAL.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BarbershopDB databaseContext;

        protected readonly DbSet<TEntity> table;

        public async Task<IEnumerable<TEntity>> GetAsync() => await table.ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public abstract Task<TEntity> GetCompleteEntityAsync(int id);

        public async Task InsertAsync(TEntity entity) => await table.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity) =>
            await Task.Run(() => table.Update(entity));

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => table.Remove(entity));
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";

        public GenericRepository(BarbershopDB databaseContext)
        {
            this.databaseContext = databaseContext;
            table = this.databaseContext.Set<TEntity>();
        }
    }
}
