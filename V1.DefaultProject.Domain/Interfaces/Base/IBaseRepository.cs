using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace V1.DefaultProject.Domain.Interfaces.Base
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        TModel Get(Guid id);
        Task<TModel> GetAsync(Guid id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetAllAsync(Func<IQueryable<TModel>, IQueryable<TModel>> func = null);
        void RemoveById(Guid id);
        Task RemoveByIdAsync(Guid id);
        void Add(TModel entity);
        void AddRange(List<TModel> models);
        void Update(TModel entity);
        Task UpdateAsync(TModel entity);
        Task AddAsync(TModel entity);
        Task<Guid> Commit();
        Task<TModel> Find(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, object>>[] includes);
    }
}
