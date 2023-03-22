using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VendorApi.Service.Features.DeliveryScheduleFeature.Commands;
using VendorApi.Service.Features.DeliveryScheduleFeature.Queries;
using VendorApi.Service.Features.InvoiceDetailsFeatures.Commands;
//using VendorApi.Service.Features.DeliveryScheduleFeature.Queries;


namespace VendorApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/DeliverySchedule")]
    [ApiVersion("1.0")]
    public class DeliveryScheduleController : ControllerBase
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
            return Ok(await Mediator.Send(new GetAllDSQuery()));
        }




        /// <summary>
        /// Delivery schedule Api for supplier
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns > Supplier Details of DeliverySchedule</returns>

           [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetDSByIdQuery { Id = id }));
        }



        /// <summary>
        /// Update Delivery Schedule Api
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Add Delivery Schedule</returns>
        [HttpPut("")]
        public async Task<IActionResult> Create(UpdateDSCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(CreateIDSupplierCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
