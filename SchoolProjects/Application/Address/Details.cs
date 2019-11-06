using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class AddressDetails 
    {
        public class Query : IRequest<Address>
        {
          public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Address>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
      
      public Task<Address> Handle(Query request, CancellationToken cancellationToken)
      {
        var value = _context.Addresses.FindAsync(request.Id);
        return value;
      }
    }

  }
}