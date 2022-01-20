using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using V1.DefaultProject.WebApi.Models;

namespace V1.DefaultProject.WebApi.Controllers
{
    public partial class HomeController 
    {

        [HttpGet]
        [Route("GetProjectDefault")]

        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
    }
}
