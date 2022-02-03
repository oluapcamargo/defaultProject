using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace V1.DefaultProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    public partial class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
