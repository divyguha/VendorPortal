using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.DeliveryScheduleFeature.Commands
{
    public class UpdateDSCommand : IRequest<int>
    {
        public string SAPCode { get; set; }
        public int Week1 { get; set; }
        public int Week2 { get; set; }
        public int Week3 { get; set; }
        public int Week4 { get; set; }
        public int Total { get; set; }
        public int TentativeMonth1 { get; set; }
        public int TentativeMonth2 { get; set; }

        public class UpdateDeliveryScheduleCommandHandler : IRequestHandler<UpdateDSCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateDeliveryScheduleCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateDSCommand request, CancellationToken cancellationToken)
            {
                var DeliveryScheduleDetails = _context.DeliveryScheduleDetail.Where(a => a.SAPCode == request.SAPCode).FirstOrDefault();


                if (DeliveryScheduleDetails == null)
                {
                    return default;
                }
                else
                {
                    DeliveryScheduleDetails.Week1 = request.Week1;
                    DeliveryScheduleDetails.Week2 = request.Week2;
                    DeliveryScheduleDetails.Week3 = request.Week3;
                    DeliveryScheduleDetails.Week4 = request.Week4;
                    DeliveryScheduleDetails.Total = request.Total;
                    DeliveryScheduleDetails.TentativeMonth1 = request.TentativeMonth1;
                    DeliveryScheduleDetails.TentativeMonth2 = request.TentativeMonth2;

                    _context.DeliveryScheduleDetail.Update(DeliveryScheduleDetails);
                    await _context.SaveChangesAsync();
                    return DeliveryScheduleDetails.DeliveryScheduleDetailId;
                }
            }
        }

    }
}
