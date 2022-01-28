using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Domain.ViewModels.Input.Usuario;

namespace V1.DefaultProject.WebApi.Controllers
{
    public partial class UsuarioController
    {
        /// <summary>
        /// Add User.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UsuarioInput input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
    }
}
