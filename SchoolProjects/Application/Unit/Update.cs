using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
    public class UpdateUnit
    {
        public class Command : IRequest{
      public int Id { get; set; }
      public string UnitName { get; set; }
      public double? UnitMark { get; set; }
      public string Description { get; set; }
      public bool? HasLab { get; set; }
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
       var unit= await _context.Units.FindAsync(request.Id);
        if(unit==null)
        throw new Exception("could not find the value");
        unit.UnitName = request.UnitName ?? unit.UnitName;
        unit.Description = request.Description ?? unit.Description;
        unit.UnitMark = request.UnitMark ?? unit.UnitMark;
        unit.HasLab = request.HasLab ?? unit.HasLab;

        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem with updating record");
      }
    }
  }
}