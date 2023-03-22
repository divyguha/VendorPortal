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
    public class GetDSByIdSupplierQuery : IRequest<object>
    {
        public int Id { get; set; }
        public class GetDeliveryScheduleByIdSupplierQueryHandler : IRequestHandler<GetDSByIdSupplierQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetDeliveryScheduleByIdSupplierQueryHandler(IApplicationDbContext context)
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
            public async Task<object> Handle(GetDSByIdSupplierQuery request, CancellationToken cancellationToken)
            {
                //var IM= _context.InvoiceMains.Where(a => a.POMainId == request.Id).FirstOrDefault();

                var DeliveryScheduleSupplierDetails = await (from PM in _context.POMain
                                                     join PD in _context.PODetail
                                                     on PM.POId equals PD.POId
                                                     join DSM in _context.DeliveryScheduleMain
                                                     on PM.POId equals DSM.POId
                                                     join VN in _context.VendorMaster
                                                     on PM.VendorId equals VN.VendorId
                                                     join DSD in _context.DeliveryScheduleDetail
                                                     on DSM.DeliveryScheduleMainId equals DSD.DeliveryScheduleMainId
                                                     where DSD.DeliveryScheduleDetailId == request.Id
                                                     //&& IM.POMainId == request.Id                                              
                                                     select new
                                                     {

                                                         DeliveryScheduleNo = DSM.DeliveryScheduleMainId,
                                                         DeliveryScheduleDate = Convert.ToString(DSD.DeliveryScheduleDate),
                                                         PurchaseOrderNo = PM.SAPPONo,
                                                         PurchaseOrderDate = Convert.ToString(PM.PODate),
                                                         SupplierCode = DSD.SAPCode,
                                                         SupplierName = VN.SAPVendorName,
                                                         WorkingDays = DSM.DSWorkingdays,
                                                         Month = DSM.DSMonth,
                                                         MaterialCode = PD.MaterialCode,
                                                         MaterialDescription = PD.MaterialDescription,
                                                         RequestFor = PD.Qty


                                                     }


                                           ).FirstOrDefaultAsync();

                if (DeliveryScheduleSupplierDetails == null)
                {
                    return null;
                }
                return DeliveryScheduleSupplierDetails;
            }
        }
    }
}
