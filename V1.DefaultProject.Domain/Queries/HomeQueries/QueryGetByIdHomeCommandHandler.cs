using System;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.Queries.HomeQueries
{
    public partial class QueryGetByIdHomeCommandHandler
    {
        private readonly IHomeRepository _repository;

        public QueryGetByIdHomeCommandHandler(IHomeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Entities.Home.Home>> GetById(Guid id)
        {
            var result = new Result<Entities.Home.Home>();
            result.Value = await _repository.GetAsync(id);
            return result;
        }
    }
}
