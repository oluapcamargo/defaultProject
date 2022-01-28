using MediatR;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Enum;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.Util;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Application.Commands.HomeCommands
{
    public class CommandAtualizarHomeHandler : IRequestHandler<UpdateHomeInput, Result>
    {
        private readonly IHomeRepository _repository;

        public CommandAtualizarHomeHandler(IHomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateHomeInput request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var updateItem = await _repository.GetAsync(request.Codigo);
            await _repository.UpdateAsync(updateItem);
            result.Message = "Sucesso;";

            return result;
        }
    }
}
