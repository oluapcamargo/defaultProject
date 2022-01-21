using MediatR;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Home
{
    public class ObterHomeByIdInput : BaseInput, IRequest<Result<Domain.Entities.Home.Home>>
    {
    }
}
