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
    public class CommandSalvarHomeHandler : IRequestHandler<HomeInput, Result>
    {
        private readonly IHomeRepository _repository;

        public CommandSalvarHomeHandler(IHomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(HomeInput request, CancellationToken cancellationToken)
        {
            var result = new Result();
            var novoitem = new Domain.Entities.Home.Home(request.Desenvolvedor);
            await _repository.AddAsync(novoitem);
            result.Message = "Sucesso;";

            return result;
        }
    }
}
