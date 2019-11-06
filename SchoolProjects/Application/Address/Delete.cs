using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
    public class DeleteAddress
    {
        public class Command: IRequest{
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<Command>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
 
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var  exist = _context.Addresses.Any(v => v.CoordId ==request.Id);
        if(exist){
          var value = _context.Addresses.FirstOrDefault(v => v.CoordId == request.Id);
          _context.Remove(value);
        }
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem deleting the data");
      }
    }
  }
}