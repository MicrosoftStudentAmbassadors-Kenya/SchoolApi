using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Values
{
  public class StudentList
    {
        public class Query : IRequest<List<Student>>
        {
            
        }
    public class Handler : IRequestHandler<Query, List<Student>>
    {
      private readonly SchoolDbContext context;
      public Handler(SchoolDbContext _context)
      {
        context = _context;
      }
      public async Task<List<Student>> Handle(Query request, CancellationToken cancellationToken)
      {
        var values = await context.Students.ToListAsync();
        return values;
      }
    }
  }
}