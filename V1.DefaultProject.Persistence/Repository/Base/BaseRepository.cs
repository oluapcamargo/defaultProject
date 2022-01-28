using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces.Base;

namespace V1.DefaultProject.Persistence.Repository.Base
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly DbContext DatabaseContext;

        public BaseRepository(DbContext context)
        {
            this.DatabaseContext = context;
        }
        public async Task<TModel> GetAsync(Guid id)
        {
            return await DatabaseContext.Set<TModel>().FindAsync(id);
        }
        public async Task UpdateAsync(TModel entity)
        {
            DatabaseContext.Set<TModel>().Update(entity);
            await DatabaseContext.SaveChangesAsync();
        }
        public async Task AddAsync(TModel entity)
        {
            await DatabaseContext.Set<TModel>().AddAsync(entity);
            DatabaseContext.SaveChanges();
        }
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var dbSet = DatabaseContext.Set<TModel>();
            return await dbSet.ToListAsync();
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var existingEntity = await DatabaseContext.Set<TModel>().FindAsync(id);
            DatabaseContext.Remove(existingEntity);
            DatabaseContext.SaveChanges();
        }
    }
}