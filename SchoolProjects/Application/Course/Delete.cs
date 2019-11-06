using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
    public class DeleteCourse
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
        var  exist = _context.Courses.Any(v => v.CourseId ==request.Id);
        if(exist){
          var value = _context.Courses.FirstOrDefault(v => v.CourseId == request.Id);
          _context.Remove(value);
        }
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem deleting the data");
      }
    }
  }
}