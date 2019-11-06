using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Values
{
  public class ListClassRooms
    {
        public class Query : IRequest<List<Classroom>>
        {
            
        }
    public class Handler : IRequestHandler<Query, List<Classroom>>
    {
      private readonly SchoolDbContext context;
      public Handler(SchoolDbContext _context)
      {
        context = _context;
      }
      public async Task<List<Classroom>> Handle(Query request, CancellationToken cancellationToken)
      {
        var values = await context.Classrooms.ToListAsync();
        return values;
      }
    }
  }
}