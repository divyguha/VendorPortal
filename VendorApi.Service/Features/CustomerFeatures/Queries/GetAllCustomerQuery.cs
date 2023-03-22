using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.VendorFeatures.Queries
{
    public class GetAllVendorQuery : IRequest<IEnumerable<Vendor>>
    {

        public class GetAllVendorQueryHandler //: IRequestHandler<GetAllVendorQuery, IEnumerable<Vendor>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllVendorQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            //public async Task<IEnumerable<Customer>> Handle(GetAllVendorQuery request, CancellationToken cancellationToken)
            //{
            //    var vendorList = await _context.Vendors.ToListAsync();
            //    if (vendorList == null)
            //    {
            //        return null;
            //    }
            //    return vendorList.AsReadOnly();
            //}
        }
    }
}
