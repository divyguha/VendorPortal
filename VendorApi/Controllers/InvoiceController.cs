using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VendorApi.Service.Features.InvoiceDetailsFeatures;
using VendorApi.Service.Features.InvoiceDetailsFeatures.Commands;
//using VendorApi.Service.Features.InvoiceDetailsFeatures.Commands;
using VendorApi.Service.Features.InvoiceDetailsFeatures.Queries;
//using VendorApi.Service.Features.InvoiceDetailsFeatures.Queries;

namespace VendorApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InvoiceController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllIDQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetIDByIdQuery { Id = id }));
        }


        [HttpPut("")]
        public async Task<IActionResult> Create(UpdateIDCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
