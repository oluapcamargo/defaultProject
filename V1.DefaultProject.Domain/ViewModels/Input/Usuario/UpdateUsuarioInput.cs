using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Usuario
{
    public class UpdateUsuarioInput : BaseInput, IRequest<Result>
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
    }
}
