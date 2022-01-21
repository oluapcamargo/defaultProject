using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Home
{
    public class DesativarHomeInput : BaseInput, IRequest<Result>
    {
    }
}
