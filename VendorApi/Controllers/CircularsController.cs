using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorApi.Service.Features.CircularsFeatures.Queries;

namespace VendorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CircularsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCircularsQuery()));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    return Ok(await Mediator.Send(new GetCircularByIdQuery { CircularSubject = id }));
        //}

        //[HttpGet("{SAPPO}")]
        //public async Task<IActionResult> GetBySAPPONumber(string SAPPONumber)
        //{
        //    return Ok(await Mediator.Send(new GetSAPPOByPONoQuery { SAPPO = SAPPONumber }));
        //}
    }
}
