using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;


namespace VendorApi.Service.Features.POFeatures.Queries
{
    public class GetAllPOQuery : IRequest<IEnumerable<object>>
    {

        public class GetAllPOQueryHandler : IRequestHandler<GetAllPOQuery, IEnumerable<object>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPOQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<object>> Handle(GetAllPOQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var POList = await _context.POMain.ToListAsync();
                    if (POList == null)
                    {
                        return null;
                    }
                    return POList.AsReadOnly();
                } catch (Exception ex) 
                {
                    return null;
                }
                
            }
        }
    }
}
