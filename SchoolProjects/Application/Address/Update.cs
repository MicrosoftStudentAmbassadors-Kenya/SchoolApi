using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
    public class UpdateAddress
    {
        public class Command : IRequest{
      public int Id { get; set; }
      public double? Y_coord { get; set; }
      public double? x_coord { get; set; }
      public string Description { get; set; }
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
       var address = await _context.Addresses.FindAsync(request.Id);
        if(address==null)
        throw new Exception("could not find the value");
        address.X_Coord = request.x_coord ?? address.X_Coord;
        address.Y_Coord = request.Y_coord ?? address.Y_Coord;
        address.Description = request.Description ?? address.Description;

        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem with updating record");
      }
    }
  }
}