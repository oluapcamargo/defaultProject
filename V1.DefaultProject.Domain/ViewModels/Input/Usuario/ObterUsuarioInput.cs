using MediatR;
using System.Collections.Generic;
using V1.DefaultProject.Domain.ViewModels.Output.Usuario;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.ViewModels.Input.Usuario
{
    public class ObterUsuarioInput : BaseRequestFilter, IRequest<Result<UsuarioListOutput>>
    {
    }
}
