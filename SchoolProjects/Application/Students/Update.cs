using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class UpdateStudent
  {
    public class Command : IRequest
    {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int? PhoneNumber { get; set; }
      public int? Age { get; set; }
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
        var student = await _context.Students.FindAsync(request.Id);
        if (student == null)
          throw new Exception("could not find the value");
        student.FirstName = request.FirstName ?? student.FirstName;
        student.LastName = request.LastName ?? student.LastName;
        student.PhoneNumber = request.PhoneNumber ?? student.PhoneNumber;
        student.Age = request.Age ?? student.Age;

        var success = await _context.SaveChangesAsync() > 0;
        if (success) return Unit.Value;
        throw new Exception("Problem with updating record");
      }
    }
  }
}