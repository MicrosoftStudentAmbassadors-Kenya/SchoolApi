using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Unit = MediatR.Unit;

namespace Application.Values
{
  public class CreateStudent
  {
    public class Command : IRequest
    {
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public int PhoneNumber { get; set; }
     public int Age { get; set; }

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
        var student = new Student
        {
          FirstName = request.FirstName,
          LastName = request.LastName,
          PhoneNumber = request.PhoneNumber,
          Age = request.Age
        };
        _context.Students.Add(student);
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem Saving data");
      }
    }

  }
}