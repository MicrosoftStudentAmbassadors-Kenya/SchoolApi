using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class ClassroomDetails 
    {
        public class Query : IRequest<Classroom>
        {
          public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Classroom>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
      
      public Task<Classroom> Handle(Query request, CancellationToken cancellationToken)
      {
        var value = _context.Classrooms.FindAsync(request.Id);
        return value;
      }
    }

  }
}