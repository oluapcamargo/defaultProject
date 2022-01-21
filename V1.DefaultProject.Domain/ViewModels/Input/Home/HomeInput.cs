using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Home
{
    public class HomeInput : IRequest<Result>
    {
        public string Desenvolvedor { get; set; }
    }
}

