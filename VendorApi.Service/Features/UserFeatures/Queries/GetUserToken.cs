using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.UserFeatures.Queries
{
    public class GetUserTokenQuery : IRequest<IEnumerable<User>>
    {

        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllUserQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var vendorList = await _context.User.ToListAsync();
                if (vendorList == null)
                {
                    return null;
                }
                return vendorList.AsReadOnly();
            }
        }
    }
}
