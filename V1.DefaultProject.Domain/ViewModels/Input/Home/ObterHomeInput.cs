using MediatR;
using System.Collections.Generic;
using V1.DefaultProject.Domain.ViewModels.Output.Home;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Home
{
    public class ObterHomeInput : BaseRequestFilter, IRequest<Result<HomeListOutput>>
    {
    }
}
