using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.POFeatures.Queries
{
    public class GetSAPPOByPONoQuery : IRequest<POMain>
    {
        public string SAPPO { get; set; }

        public class GetSAPPOByPONoQueryHandler : IRequestHandler<GetSAPPOByPONoQuery, POMain>
        {
            private readonly IApplicationDbContext _context;
            public GetSAPPOByPONoQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<POMain> Handle(GetSAPPOByPONoQuery request, CancellationToken cancellationToken)
            {
                var PO = _context.POMain.Where(a => a.SAPPONo == request.SAPPO).FirstOrDefault();
                if (PO == null) return null;
                return PO;
            }

         }
    }
}
