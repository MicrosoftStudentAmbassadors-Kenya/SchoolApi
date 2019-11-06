using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Unit = MediatR.Unit;

namespace Application.Values
{
  public class CreateCourse
  {
    public class Command : IRequest
    {
     public int Id { get; set; }
     public int NumberofYears { get; set; }
     public int NumberOfUnits { get; set; }

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
        var course = new Course
        {
          NumberofUnits = request.NumberOfUnits,
          NumberofYears = request.NumberofYears
        };
        _context.Courses.Add(course);
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem Saving data");
      }
    }

  }
}