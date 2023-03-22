using MediatR;
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
    public class GetCircularByIdQuery : IRequest<IEnumerable<Circular>>
    {
        private readonly string CircularSubject;

        public class GetCircularByIdQueryHandler : IRequestHandler<GetCircularByIdQuery, IEnumerable<Circular>>
        {
            public string CircularSubject { get; set; }
            private readonly IApplicationDbContext _context;
            public GetCircularByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Circular>> Handle(GetCircularByIdQuery request, CancellationToken cancellationToken)
            {
                var CircularsMain =  _context.Circulars.Where(a => a.CircularSubject == request.CircularSubject).FirstOrDefault();


                if (CircularsMain == null)
                {
                    return null;
                }
                return (IEnumerable<Circular>)CircularsMain;
            }
        }

    }
}
