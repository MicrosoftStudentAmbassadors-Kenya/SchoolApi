using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Values
{
  public class ListCourses
    {
        public class Query : IRequest<List<Course>>
        {
            
        }
    public class Handler : IRequestHandler<Query, List<Course>>
    {
      private readonly SchoolDbContext context;
      public Handler(SchoolDbContext _context)
      {
        context = _context;
      }
      public async Task<List<Course>> Handle(Query request, CancellationToken cancellationToken)
      {
        var values = await context.Courses.ToListAsync();
        return values;
      }
    }
  }
}