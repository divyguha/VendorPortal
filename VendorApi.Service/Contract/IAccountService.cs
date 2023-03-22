using System.Threading.Tasks;
using VendorApi.Domain.Auth;
using VendorApi.Domain.Common;

namespace VendorApi.Service.Contract
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);

        //Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        
        Task ForgotPassword(ForgotPasswordRequest request, string origin);
        
        Task<Response<string>> ResetPassword(ResetPasswordRequest request);
    }
}
