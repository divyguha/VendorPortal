using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.DeliveryScheduleFeature.Queries
{
    public class GetAllDSSupplierQuery : IRequest<IEnumerable<object>>
    {

        public class GetAllDeliveryScheduleSupplierQueryHandler : IRequestHandler<GetAllDSSupplierQuery, IEnumerable<object>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllDeliveryScheduleSupplierQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<object>> Handle(GetAllDSSupplierQuery request, CancellationToken cancellationToken)
            {

                var DeliveryScheduleSpplier = await (from pm in _context.POMain
                                                     join dsm in _context.DeliveryScheduleMain
                                                     on pm.POId equals dsm.POId
                                                     join dsd in _context.DeliveryScheduleDetail
                                                     on dsm.DeliveryScheduleMainId equals dsd.DeliveryScheduleMainId

                                                     select new
                                                     {
                                                         PurchaseOrderNo = pm.SAPPONo,
                                                         PODate = Convert.ToString(pm.PODate),
                                                         DeliveryScheduleNo=dsm.DeliveryScheduleMainId,
                                                         DeliveryScheduledate=Convert.ToString(dsd.DeliveryScheduleDate)



                                                     }).ToListAsync();
                

                if (DeliveryScheduleSpplier == null)
                {
                    return null;
                }
                return (IEnumerable<object>)DeliveryScheduleSpplier.AsReadOnly();


            }

        }

    }
}
