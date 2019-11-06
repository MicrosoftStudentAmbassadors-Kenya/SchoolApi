using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Unit = MediatR.Unit;

namespace Application.Values
{
  public class CreateClassroom
  {
    public class Command : IRequest
    {
     public int Id { get; set; }
     public string Name { get; set; }
     
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
        var classroom = new Classroom
        {
          ClassId = request.Id,
          ClassroomName = request.Name
        };
        _context.Classrooms.Add(classroom);
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem Saving data");
      }
    }

  }
}