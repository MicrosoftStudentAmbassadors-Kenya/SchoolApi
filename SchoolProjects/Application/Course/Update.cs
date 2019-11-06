using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class UpdateCourse
  {
    public class Command : IRequest
    {
      public int Id { get; set; }
      public int? NumberofYears { get; set; }
      public int? NumberOfUnits { get; set; }
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
        var course = await _context.Courses.FindAsync(request.Id);
        if (course == null)
          throw new Exception("could not find the value");
        course.NumberofUnits = request.NumberOfUnits ?? course.NumberofUnits;
        course.NumberofYears = request.NumberofYears ?? course.NumberofYears;

        var success = await _context.SaveChangesAsync() > 0;
        if (success) return Unit.Value;
        throw new Exception("Problem with updating record");
      }
    }
  }
}