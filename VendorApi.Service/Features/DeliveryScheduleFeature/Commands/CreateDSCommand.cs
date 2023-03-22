using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.DeliveryScheduleFeature.Commands
{


    public class CreateDSCommand : IRequest<int>
    {
        public string MaterialDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SAPCode { get; set; }
        public int Week1 { get; set; }
        public int Week2 { get; set; }
        public int Week3 { get; set; }
        public int Week4 { get; set; }
        public int Total { get; set; }
        public int TentativeMonth1 { get; set; }
        public int TentativeMonth2 { get; set; }

        public class CreateDSCommandHandler : IRequestHandler<CreateDSCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateDSCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateDSCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    //var DeliveryScheduleDetails = _context.DeliveryScheduleDetails.Where(a => a.SAPCode == request.SAPCode).FirstOrDefault();
                    var deliveryScheduleDetail = new DeliveryScheduleDetail();


                    if (deliveryScheduleDetail == null)
                    {
                        return default;
                    }
                    else
                    {

                        deliveryScheduleDetail.MaterialDescription = request.MaterialDescription;
                        deliveryScheduleDetail.SAPCode = request.SAPCode;
                        deliveryScheduleDetail.CreatedDate = request.CreatedDate;
                        deliveryScheduleDetail.Week1 = request.Week1;
                        deliveryScheduleDetail.Week2 = request.Week2;
                        deliveryScheduleDetail.Week3 = request.Week3;
                        deliveryScheduleDetail.Week4 = request.Week4;
                        deliveryScheduleDetail.Total = request.Total;
                        deliveryScheduleDetail.TentativeMonth1 = request.TentativeMonth1;
                        deliveryScheduleDetail.TentativeMonth2 = request.TentativeMonth2;
                        deliveryScheduleDetail.DeliveryScheduleMainId = 7;
                        deliveryScheduleDetail.venMaterialDescription = null;
                        deliveryScheduleDetail.venSAPCode = 0;
                        deliveryScheduleDetail.vendorWeek1 = 0;
                        deliveryScheduleDetail.vendorWeek2 = 0;
                        deliveryScheduleDetail.vendorWeek3 = 0;
                        deliveryScheduleDetail.vendortotal = 0;
                        deliveryScheduleDetail.venTentativeMonth1 = 0;
                        deliveryScheduleDetail.venTentativeMonth2 = 0;
                        deliveryScheduleDetail.DailyDeliveryQty = 0;
                        deliveryScheduleDetail.DailyReceivedQty = 0;
                        deliveryScheduleDetail.Gap = 0;
                        deliveryScheduleDetail.CarryForward = 0;
                        deliveryScheduleDetail.Unit = null;
                        deliveryScheduleDetail.DeliveryScheduleType = null;
                        deliveryScheduleDetail.DeliveryScheduleDate = DateTime.Now;


                        _context.DeliveryScheduleDetail.Add(deliveryScheduleDetail);
                        await _context.SaveChangesAsync();
                        return deliveryScheduleDetail.DeliveryScheduleDetailId;
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
