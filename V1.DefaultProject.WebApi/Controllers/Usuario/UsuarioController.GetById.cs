﻿using System;
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
        /// Search one User by filter.
        /// </summary>
        [HttpGet]
        [Route("getById")]

        public async Task<IActionResult> GetById([FromQuery] ObterUsuarioByIdInput input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
    }
}