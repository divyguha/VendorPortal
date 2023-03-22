using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorApi.Service.Features.DeliveryScheduleFeature.Queries;

namespace VendorApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/DeliveryScheduleSupplier")]
    [ApiVersion("1.0")]
    public class DeliveryScheduleSupplierController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Delivery schedule Api for Admin 
        /// </summary>
        /// <returns> All Supplier Details of DeliverySchedule</returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllDSSupplierQuery()));
        }



        /// <summary>
        /// Delivery schedule Api for supplier
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns > Supplier Details of DeliverySchedule</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetDSByIdSupplierQuery { Id = id }));
        }

    }
}

