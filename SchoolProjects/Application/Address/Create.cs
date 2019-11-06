using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Unit = MediatR.Unit;

namespace Application.Values
{
  public class CreateAddress
  {
    public class Command : IRequest
    {
     public int Id { get; set; }
     public double Y_coord { get; set; }
     public double x_coord { get; set; }
     public string Description { get; set; }
    }
    public class RequestHandler : IRequestHandler<Command>
    {
      private readonly SchoolDbContext _context;
      public RequestHandler(SchoolDbContext context)
      {
        _context = context;
      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var address = new Address
        {
          CoordId = request.Id,
          Y_Coord = request.Y_coord,
          X_Coord = request.x_coord,
          Description = request.Description
      };
        _context.Addresses.Add(address);
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem Saving data");
      }
    }

  }
}