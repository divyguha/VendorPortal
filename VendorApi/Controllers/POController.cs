using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Service.Features.POFeatures.Queries;


namespace VendorApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/PO")]
    [ApiVersion("1.0")]
    public class POController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPOQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPOByIdQuery { Id = id }));
        }
       // [HttpGet]
        //[Route("")]
      //  public async Task<IActionResult> GetPOdetails(int poID)
        //{
           // var obj = new PODetail();
            //var result = await Mediator.Send(new PODetail().GetPoDeatil(poID));
            //return Ok(result);
        //}
        //[HttpGet("{SAPPO}")]
        //public async Task<IActionResult> GetBySAPPONumber(string SAPPONumber)
        //{
        //    return Ok(await Mediator.Send(new GetSAPPOByPONoQuery { SAPPO = SAPPONumber }));
        //}
    }
}
