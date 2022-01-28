using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.Queries.HomeQueries
{
    public partial class QueryGetByIdHomeCommandHandler : IRequestHandler<ObterHomeByIdInput, Result<Entities.Home.Home>>
    {
        private readonly IHomeRepository _repository;

        public QueryGetByIdHomeCommandHandler(IHomeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Entities.Home.Home>> Handle(ObterHomeByIdInput input, CancellationToken cancellationToken)
        {
            var result = new Result<Entities.Home.Home>();
            result.Value = await _repository.GetAsync(input.Codigo);
            return result;
        }
    }
}
