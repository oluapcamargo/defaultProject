using MediatR;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Usuario;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Application.Commands.UsuarioCommands
{
    public class CommandAtivarouDesativarUsuarioHandler : IRequestHandler<DesativarUsuarioInput, Result>
    {
        private readonly IUsuarioRepository _repository;

        public CommandAtivarouDesativarUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DesativarUsuarioInput request, CancellationToken cancellationToken)
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
