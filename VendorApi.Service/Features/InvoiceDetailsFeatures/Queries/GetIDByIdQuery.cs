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

namespace VendorApi.Service.Features.InvoiceDetailsFeatures.Queries
{
    public class GetIDByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
        public class GetManageAllInvoiceDetailsByIdQueryHandler : IRequestHandler<GetIDByIdQuery, object>
        {
            private readonly IApplicationDbContext _context;
            public GetManageAllInvoiceDetailsByIdQueryHandler(IApplicationDbContext context)
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
            public async Task<object> Handle(GetIDByIdQuery request, CancellationToken cancellationToken)
            {
                //var IM= _context.InvoiceMains.Where(a => a.POMainId == request.Id).FirstOrDefault();

                try
                {
                    //int id1 = request.Id;
                    var InvoiceDetailsById = await (from PM in _context.POMain
                                                    join IM in _context.InvoiceMain
                                                    on PM.POId equals IM.POId
                                                    join PD in _context.PODetail
                                                    on PM.POId equals PD.POId
                                                    join VN in _context.VendorMaster
                                                    on IM.VendorId equals VN.VendorId
                                                    where PM.POId == request.Id
                                                    select new
                                                    {
                                                        InvoiceNumber = IM.InvoiceNo,
                                                        InvoiceDate = IM.InvoiceDate,
                                                        consigneeName = IM.NameOfConsignee,
                                                        TransportName = IM.TransporterName,
                                                        ModeOfTransport = IM.ModeOfTransport,
                                                        VehicleNumber = IM.VehicleNo,

                                                        PONumber = PM.SAPPONo,
                                                        PoDate = Convert.ToDateTime (PM.PODate),
                                                        TinNumber = PM.TINNo,
                                                        EccNumber = PM.ECCNo,
                                                        PanNumber = PM.PANNo,
                                                        SupplierContactPerson = IM.TransporterName,
                                                        //validFrom =Convert.ToDateTime(PM.ValidFrom),
                                                        //ValidTo = Convert.ToDateTime(PM.ValidTo),
                                                         ServiceTaxNumber = PM.SRVTaxNo,
                                                        //SupplierCode = PM.SAPVendorCode,
                                                        SpplierAddress = VN.Address,
                                                         //PlantCode = VN.PlantCode,

                                                        MaterialDescription = PD.MaterialDescription,
                                                        materialCode = PD.MaterialCode,
                                                        //NoOfPkts = ID.NoOfPKTS,
                                                        //Quantity = PD.Qty,
                                                        //PricePerUnit = PD.PricePerUnit,
                                                        //GrossValue = PD.GrossValue,
                                                        CenvatOrServiceTax = IM.Cenvat,
                                                        //CenvatorServiceTax = IM.Cenvat,
                                                        Edcs = IM.EDCess,
                                                        //EDcs = IM.EDCess,
                                                        Shecess = IM.SHECess,
                                                        //SHecess = IM.SHECess,
                                                        //taxable = ?
                                                        //VatAmount = ?
                                                        //Packaging = ID.Packaging

                                                    }


                                              ).FirstOrDefaultAsync();

                    if (InvoiceDetailsById == null)
                    {
                        return null;
                    }
                    return InvoiceDetailsById;
                }
                catch(Exception ex)
                {
                    return ex;
                }
            }

        }
    }
}
