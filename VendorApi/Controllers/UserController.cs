﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using VendorApi.Service.Features.UserFeatures.Queries;


namespace VendorApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/User")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUserQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }
    }
}
