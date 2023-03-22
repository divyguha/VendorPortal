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

namespace VendorApi.Service.Features.DeliveryScheduleFeature.Queries
{
    public class GetDSByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
        public class GetManageDeliveryScheduleByIdQueryHandler : IRequestHandler<GetDSByIdQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetManageDeliveryScheduleByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }


            /// <summary>
            /// Use Joins
            /// return View Invoice Details from Pomains,InvoiceMains, PoDetails, Vendor tables By Id
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<object>Handle(GetDSByIdQuery request, CancellationToken cancellationToken)
            {
                //var IM= _context.InvoiceMains.Where(a => a.POMainId == request.Id).FirstOrDefault();

                var DeliveryScheduleDetails = await (from PM in _context.POMain
                                                         join PD in _context.PODetail
                                                         on PM.POId equals PD.POId
                                                         join DSM in _context.DeliveryScheduleMain
                                                         on PM.POId equals DSM.POId
                                                         join VN in _context.VendorMaster
                                                         on PM.VendorId equals VN.VendorId
                                                         join DSD in _context.DeliveryScheduleDetail
                                                         on DSM.DeliveryScheduleMainId equals DSD.DeliveryScheduleMainId
                                                         where DSD.DeliveryScheduleMainId == request.Id
                                                         //&& IM.POMainId == request.Id                                              
                                                         select new
                                                         {

                                                             DeliveryScheduleNo = DSM.DeliveryScheduleMainId,
                                                             DeliveryScheduleDate =Convert.ToString (DSD.DeliveryScheduleDate),
                                                             PurchaseOrderNo = PM.SAPPONo,
                                                             PurchaseOrderDate =Convert.ToString (PM.PODate),
                                                             SupplierCode = DSD.SAPCode,
                                                             SupplierName = VN.SAPVendorName,
                                                             MaterialCode = PD.MaterialCode,
                                                             MaterialDescription = PD.MaterialDescription,
                                                             Unit = PD.Unit,
                                                             RequestFor = PD.Qty


                                                         }


                                           ).FirstOrDefaultAsync();

                if (DeliveryScheduleDetails == null)
                {
                    return null;
                }
                return DeliveryScheduleDetails;
            }
        }
    }
}
