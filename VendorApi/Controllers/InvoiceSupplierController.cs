using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorApi.Service.Features.InvoiceDetailsFeatures;
using VendorApi.Service.Features.InvoiceDetailsFeatures.Commands;

namespace VendorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InvoiceSupplierController : ControllerBase
    {
         
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllIDSupplierQuery()));
        }

        /// <summary>
        /// Update Delivery Schedule Api
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Add Delivery Schedule</returns>
        [HttpPost("")]
        public async Task<IActionResult> Create(CreateIDSupplierCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
