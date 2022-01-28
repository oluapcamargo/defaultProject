using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Domain.ViewModels.Input.Usuario;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.Queries.UsuarioQueries
{
    public partial class QueryGetByIdUsuarioCommandHandler : IRequestHandler<ObterUsuarioByIdInput, Result<Entities.Usuario>>
    {
        private readonly IUsuarioRepository _repository;

        public QueryGetByIdUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Entities.Usuario>> Handle(ObterUsuarioByIdInput input, CancellationToken cancellationToken)
        {
            var result = new Result<Entities.Usuario>();
            result.Value = await _repository.GetAsync(input.Codigo);
            return result;
        }
    }
}
