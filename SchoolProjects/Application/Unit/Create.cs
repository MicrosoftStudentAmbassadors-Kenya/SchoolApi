using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Unit = MediatR.Unit;

namespace Application.Values
{
  public class CreateUnit
  {
    public class Command : IRequest
    {
     public int Id { get; set; }
     public string UnitName { get; set; }
     public string Description { get; set; }
     public bool HasLab { get; set; }
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
        var unit = new Domain.Unit
        {
          UnitName = request.UnitName,
          Description = request.Description,
          HasLab = request.HasLab
        };
        _context.Units.Add(unit);
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem Saving data");
      }
    }

  }
}