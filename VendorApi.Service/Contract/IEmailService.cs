using System.Threading.Tasks;
using VendorApi.Domain.Settings;

namespace VendorApi.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
