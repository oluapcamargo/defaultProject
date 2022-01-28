using MediatR;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Usuario
{
    public class ObterUsuarioByIdInput : BaseInput, IRequest<Result<Domain.Entities.Usuario>>
    {
    }
}
