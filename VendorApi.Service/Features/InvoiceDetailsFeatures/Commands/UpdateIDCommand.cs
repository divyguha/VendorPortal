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

namespace VendorApi.Service.Features.InvoiceDetailsFeatures.Commands
{
    public class UpdateIDCommand : IRequest<int>
    {
        public int INVId { get; set; }
        public string GRNNo { get; set; }
        public string GRNDate { get; set; }

        public class UpdateInvoiceDetailsCommandHandler : IRequestHandler<UpdateIDCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateInvoiceDetailsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateIDCommand request, CancellationToken cancellationToken)
            {
                var InvoiceMain = _context.InvoiceMain.Where(a => a.INVId == request.INVId).FirstOrDefault();


                if (InvoiceMain == null)
                {
                    return default;
                }
                else
                {
                    InvoiceMain.GRNNo = request.GRNNo;
                    InvoiceMain.GRNDate = request.GRNDate;

                    _context.InvoiceMain.Update(InvoiceMain);
                    await _context.SaveChangesAsync();
                    return InvoiceMain.INVId;
                }
            }
        }
    }
}


