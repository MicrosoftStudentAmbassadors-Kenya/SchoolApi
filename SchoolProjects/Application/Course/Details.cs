using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class DetailsCourse 
    {
        public class Query : IRequest<Course>
        {
          public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Course>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
      
      public Task<Course> Handle(Query request, CancellationToken cancellationToken)
      {
        var value = _context.Courses.FindAsync(request.Id);
        return value;
      }
    }

  }
}