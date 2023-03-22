using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;



namespace VendorApi.Service.Features.InvoiceDetailsFeatures
{
    public class GetAllIDQuery : IRequest<IEnumerable<object>>
    {

        public class GetManageAllInvoiceDetailsHandler : IRequestHandler<GetAllIDQuery, IEnumerable<object>>
        {
            private readonly IApplicationDbContext _context;
            private object person;

            public GetManageAllInvoiceDetailsHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Use Join Query.
            /// return invoice Details from InvoiceMians, PoDetails & Vendor tables all details 
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<IEnumerable<object>> Handle(GetAllIDQuery request, CancellationToken cancellationToken)

            {
                // ArrayList details = new ArrayList();

                //var a = await (from pm _context.InvoiceMain
                //               join po in _context.PODetails on pm.PoMainId equals po.POMainId
                //               select new
                //               {
                //                   po.MaterialCode,
                //                   po.MaterialDescription
                //               }
                //        ).FirstOrDefaultAsync();
                //return null;

             
                var InvoiceDetails = await (from IM in _context.InvoiceMain
                                            join PD in _context.PODetail
                                            on IM.POId equals PD.POId
                                            join VN in _context.VendorMaster
                                            on IM.VendorId equals VN.VendorId
                                            select new
                                            {
                                                SupplierCode = VN.SAPVendorCode,
                                                SupplierName = VN.SAPVendorName,
                                                PurchaesOrderNo = PD.PONumber,
                                                InvoiceNo = IM.InvoiceNo,
                                                InvoiceDate = IM.InvoiceDate
                                            }


                                          ).ToListAsync();


                if (InvoiceDetails == null)
                {
                    return null;
                }
                return InvoiceDetails.AsReadOnly();
                
            }
        }
    }
}

