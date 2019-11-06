using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class StudentDetails 
    {
        public class Query : IRequest<Student>
        {
          public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Student>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
      
      public Task<Student> Handle(Query request, CancellationToken cancellationToken)
      {
        var value = _context.Students.FindAsync(request.Id);
        return value;
      }
    }

  }
}