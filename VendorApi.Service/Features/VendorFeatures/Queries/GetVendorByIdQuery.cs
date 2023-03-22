using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;
using VendorApi.Persistence;

namespace VendorApi.Service.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly IApplicationDbContext _context;
            public GetUserByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = _context.User.Where(a => a.UserId == request.Id).FirstOrDefault();
                if (user == null) return null;
                return user;
            }
        }
    }
}
