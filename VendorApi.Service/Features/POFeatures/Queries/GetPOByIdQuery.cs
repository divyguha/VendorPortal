using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.POFeatures.Queries
{
    public class GetPOByIdQuery : IRequest<POMain>
    {
        public int Id { get; set; }
        public class GetPOByIdQueryHandler : IRequestHandler<GetPOByIdQuery,POMain>
        {
            private readonly IApplicationDbContext _context;
            public GetPOByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<POMain> Handle(GetPOByIdQuery request, CancellationToken cancellationToken)
            {
                var PO = _context.POMain.Where(a => a.POId == request.Id).FirstOrDefault();
                if (PO == null) return null;
                return PO;
            }
        }
    }
}
