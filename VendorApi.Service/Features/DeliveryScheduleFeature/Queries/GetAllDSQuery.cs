using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;
using System.Linq;
using System;

namespace VendorApi.Service.Features.DeliveryScheduleFeature.Queries
{
    public class GetAllDSQuery : IRequest<IEnumerable<object>>
    {

        public class GetAllManageDeliveryScheduleHandler : IRequestHandler<GetAllDSQuery, IEnumerable<object>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllManageDeliveryScheduleHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<object>> Handle(GetAllDSQuery request, CancellationToken cancellationToken)
            {



                var DeliveryScheduleObj = await (from dm in _context.DeliveryScheduleMain
                                                 join pm in _context.POMain
                                                on dm.POId equals pm.POId
                                                 join podetail in _context.PODetail 
                                                 on pm.POId equals podetail.POId
                                                 join dsd in _context.DeliveryScheduleDetail
                                                 on dm.DeliveryScheduleMainId equals dsd.DeliveryScheduleMainId
                                                 join v in _context.VendorMaster on dm.VendorId equals v.VendorId
                                                 select new
                                                 {
                                                     SupplierVendorName = v.SAPVendorName,
                                                     SAPPONo = pm.SAPPONo,
                                             
                                                     //PODate = pm.PODate.ToString("dd/MM/yyyy HH:mm:ss"),
                                                     PODate = Convert.ToString(pm.PODate),
                                                     delivaryScheduledNo = dm.DeliveryScheduleMainId,
                                                     //PODate = pm.PODate.ToString("dd/MM/yyyy HH:mm:ss"),
                                                     DeliveryScheduleDate = dsd.DeliveryScheduleDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                                     CreatedBy = v.EnteredBy,
                                                     CreatedDate = dm.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"),
                                                     LastUpdatedDate = dm.ModifiedDate,
                                                     LastUpdatedBy = dm.ModifiedBy,
                                                     //SAPVendorCode = v.SAPVendorCode,
                                                     //MaterialCode = podetails.MaterialCode,
                                                     //MaterialDescription = podetails.MaterialDescription

                                                 }).ToListAsync();
               

                if (DeliveryScheduleObj == null)
                {
                    return null;
                }
                return (IEnumerable<object>)DeliveryScheduleObj.AsReadOnly();


            }

        }

    }
}
