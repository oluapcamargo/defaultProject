using MediatR;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Enum;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.Util;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Domain.ViewModels.Input.Usuario;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Application.Commands.UsuarioCommands
{
    public class CommandSalvarUsuarioHandler : IRequestHandler<UsuarioInput, Result>
    {
        private readonly IUsuarioRepository _repository;

        public CommandSalvarUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UsuarioInput request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var novoitem = new Domain.Entities.Usuario(request.Nome, request.Documento, request.Email);
            await _repository.AddAsync(novoitem);
            result.Message = "Sucesso;";

            return result;
        }
    }
}
