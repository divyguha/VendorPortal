using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.VendorFeatures.Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<Vendor>>
    {

        public class GetAllVendorQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<Vendor>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllVendorQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Vendor>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var vendorList = await _context.VendorMaster.ToListAsync();
                if (vendorList == null)
                {
                    return null;
                }
                return vendorList.AsReadOnly();
            }
        }
    }
}
