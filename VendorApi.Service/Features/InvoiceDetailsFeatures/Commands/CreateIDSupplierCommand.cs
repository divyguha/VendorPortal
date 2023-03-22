using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.InvoiceDetailsFeatures.Commands
{
    public class CreateIDSupplierCommand : IRequest<int>
    {
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string NameOfConsignee { get; set; }
        public string TransporterName { get; set; }
        public string ModeOfTransport { get; set; }
        public string VehicleNo { get; set; }
        public string Cenvat { get; set; }
        public string EDCess { get; set; }
        public string SHECess { get; set; }
        public string STax { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public int NoOfPKTS { get; set; }
        public int TotalQuantityDespatched { get; set; }
        public int PricePerUnit { get; set; }
        public int TotalInvoiceAmount { get; set; }

        /// <summary>
        /// For testing purpose we can use.
        /// </summary>
        public class CreateInvoiceDetailsSupplierCommandHandler : IRequestHandler<CreateIDSupplierCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateInvoiceDetailsSupplierCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateIDSupplierCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    //var DeliveryScheduleDetails = _context.DeliveryScheduleDetails.Where(a => a.SAPCode == request.SAPCode).FirstOrDefault();
                    // var deliveryScheduleDetail = new DeliveryScheduleDetail();
                    var InvoiceMain = new InvoiceMain();
                    var InvoiceDetail = new InvoiceDetail();


                    if (InvoiceMain == null)
                    {
                        return default;
                    }
                    else
                    {
                        InvoiceMain.InvoiceNo = request.InvoiceNo;
                        InvoiceMain.InvoiceDate = request.InvoiceDate;
                        InvoiceMain.NameOfConsignee = request.NameOfConsignee;
                        InvoiceMain.TransporterName = request.TransporterName;
                        InvoiceMain.ModeOfTransport = request.ModeOfTransport;
                        InvoiceMain.VehicleNo = request.VehicleNo;
                        InvoiceMain.Cenvat = request.Cenvat;
                        InvoiceMain.EDCess = request.EDCess;
                        InvoiceMain.SHECess = request.SHECess;
                        InvoiceMain.STax = request.STax;
                        InvoiceDetail.MaterialCode = request.MaterialCode;
                        InvoiceDetail.TotalQuantityDespatched = request.TotalQuantityDespatched;
                        InvoiceDetail.PricePerUnit = request.PricePerUnit;
                        InvoiceDetail.TotalInvoiceAmount = request.TotalInvoiceAmount;
                        InvoiceDetail.INVId = 8;
                        InvoiceMain.POId = 37;





                        _context.InvoiceMain.Add(InvoiceMain);
                        _context.InvoiceDetail.Add(InvoiceDetail);
                        await _context.SaveChangesAsync();
                        return InvoiceMain.INVId;

                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
    }
}

