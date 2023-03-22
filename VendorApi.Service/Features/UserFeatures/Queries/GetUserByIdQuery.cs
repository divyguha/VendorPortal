using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.VendorFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<Vendor>
    {
        public int Id { get; set; }
        public class GetVendorByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Vendor>
        {
            private readonly IApplicationDbContext _context;
            public GetVendorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Vendor> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                //var vendor = await _context.Vendors.Where(a => a.VendorId == request.VendorId).FirstOrDefault();
                var vendor = await _context.VendorMaster.Where(a => a.VendorId == request.Id).SingleOrDefaultAsync();
                if (vendor == null) return null;
                return vendor;
            }
        }
    }
}
