using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.CustomerFeatures.Commands
{
    public class DeleteVendorByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteVendorByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCustomerByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteVendorByIdCommand request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (customer == null) return default;
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer.Id;
            }
        }
    }
}
