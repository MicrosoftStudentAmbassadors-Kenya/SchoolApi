using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Values
{
    public class DeleteClassroom
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
        var  exist = _context.Classrooms.Any(v => v.ClassId ==request.Id);
        if(exist){
          var classroom = _context.Classrooms.FirstOrDefault(v => v.ClassId == request.Id);
          _context.Remove(classroom);
        }
        var success = await _context.SaveChangesAsync() > 0;
        if(success) return Unit.Value;
        throw new Exception("Problem deleting the data");
      }
    }
  }
}