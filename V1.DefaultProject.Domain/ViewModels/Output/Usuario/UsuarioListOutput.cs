using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Domain.ViewModels.Output.Base;

namespace V1.DefaultProject.Domain.ViewModels.Output.Usuario
{
    public class UsuarioListOutput : BaseResponseOutput
    {
        public IEnumerable<Domain.Entities.Usuario> data { set; get; }
    }
}
