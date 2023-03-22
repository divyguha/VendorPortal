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

namespace VendorApi.Service.Features.CircularsFeatures.Queries
{
    public class GetAllCircularsQuery : IRequest<IEnumerable<Circular>>
    {

        public class GetAllCircularsQueryHandler : IRequestHandler<GetAllCircularsQuery, IEnumerable<Circular>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCircularsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Circular>> Handle(GetAllCircularsQuery request, CancellationToken cancellationToken)
            {
                var CircularsMain =await _context.Circulars.ToListAsync();


                if (CircularsMain == null)
                {
                    return null;
                }
                return CircularsMain.AsReadOnly();
            }
        }

    }
}
