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
        Task<TModel> GetAsync(Guid id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task RemoveByIdAsync(Guid id);
        Task UpdateAsync(TModel entity);
        Task AddAsync(TModel entity);
    }
}
