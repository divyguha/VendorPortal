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
    public class GetAllIDSupplierQuery : IRequest<IEnumerable<object>>
    {

        public class GetManageAllInvoiceDetailsSupplierHandler : IRequestHandler<GetAllIDSupplierQuery, IEnumerable<object>>
        {
            private readonly IApplicationDbContext _context;
            private object person;

            public GetManageAllInvoiceDetailsSupplierHandler(IApplicationDbContext context)
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
            public async Task<IEnumerable<object>> Handle(GetAllIDSupplierQuery request, CancellationToken cancellationToken)

            {
                var InvoiceSupplierDetails = await (from PM in _context.POMain
                                            join IM in _context.InvoiceMain
                                            on PM.POId equals IM.POId
                                            join ID in _context.InvoiceDetail
                                            on IM.INVId equals ID.INVId                                            select new
                                            {
                                                PurchaseOrderNo  = PM.SAPPONo,
                                                InvoiceNo = IM.InvoiceNo,
                                                InvoiceDate = IM.InvoiceDate
                                            }


                                          ).ToListAsync();


                if (InvoiceSupplierDetails == null)
                {
                    return null;
                }
                return (IEnumerable<object>)InvoiceSupplierDetails.AsReadOnly();

            }
        }
    }
}

