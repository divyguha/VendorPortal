using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VendorApi.Domain.Auth;
using VendorApi.Service.Contract;

namespace VendorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            // TODO check authenticate

            return Ok(await _accountService.AuthenticateAsync(request, GenerateIPAddress()));
        }

        /// <summary>
        /// This method is use to register Admin and Supplier User 
        /// </summary>
        /// <param name="request"> Send request of register user </param>
        /// <returns>"message": User Registered with Email</returns>
        /// <returns>"ErrorMessage": "User Email id already Exits."</returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
             
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin));
            
        }
               
        //[HttpGet("confirm-email")]
        //public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        //{
        //    var origin = Request.Headers["origin"];
        //    //return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        //    return Ok();
        //}


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            // TODO check forgot-password
            await _accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok();
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            // TODO check reset-password
            return Ok(await _accountService.ResetPassword(model));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}