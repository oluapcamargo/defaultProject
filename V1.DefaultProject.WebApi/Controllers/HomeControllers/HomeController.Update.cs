using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using V1.DefaultProject.Domain.ViewModels.Input.Home;

namespace V1.DefaultProject.WebApi.Controllers
{
    public partial class HomeController 
    {

        /// <summary>
        /// Update one Home by filter.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHomeInput input)
        {
            var result = await _mediator.Send(input);
            return Ok(result);
        }
    }
}
