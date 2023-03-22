using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VendorApi.Service.Features.POFeatures.Queries;

namespace VendorApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/PODetails")]
    [ApiVersion("1.0")]
    public class PoDetailsController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPoDetail { Id = id }));
        }

    }
}
