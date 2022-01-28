using MediatR;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Usuario;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Application.Commands.UsuarioCommands
{
    public class CommandAtualizarUsuarioHandler : IRequestHandler<UpdateUsuarioInput, Result>
    {
        private readonly IUsuarioRepository _repository;

        public CommandAtualizarUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateUsuarioInput request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var updateItem = await _repository.GetAsync(request.Codigo);
            updateItem.DataUltimaAtualizacao = System.DateTime.Now;
            updateItem.Documento = request.Documento;
            updateItem.Email = request.Email;
            updateItem.Nome = request.Nome;
            await _repository.UpdateAsync(updateItem);
            result.Message = "Sucesso;";

            return result;
        }
    }
}
