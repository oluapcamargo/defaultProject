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
    public class CommandAtivarouDesativarHomeHandler : IRequestHandler<DesativarHomeInput, Result>
    {
        private readonly IHomeRepository _repository;

        public CommandAtivarouDesativarHomeHandler(IHomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DesativarHomeInput request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var updateItem = await _repository.GetAsync(request.Codigo);
            updateItem.Desativar();
            await _repository.UpdateAsync(updateItem);
            result.Message = "Sucesso;";

            return result;
        }
    }
}
