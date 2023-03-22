using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.POFeatures.Queries
{
    public  class GetPoDetail:IRequest<IEnumerable <PODetail>>
    {
        public int Id { get; set; }
        public class GetPoDetailHandler : IRequestHandler<GetPoDetail, IEnumerable<PODetail>>
        {
            private readonly IApplicationDbContext _context;
            public GetPoDetailHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<PODetail>> Handle(GetPoDetail request, CancellationToken cancellationToken)
            {
                var POD = _context.PODetail.Where(a => a.POId == request.Id).ToArrayAsync();
                if (POD == null)   return null;
                return await POD;
            }
        }
    }
}
