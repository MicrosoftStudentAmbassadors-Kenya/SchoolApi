using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Values
{
  public class List
    {
        public class Query : IRequest<List<Value>>
        {
            
        }
    public class Handler : IRequestHandler<Query, List<Value>>
    {
      private readonly SchoolDbContext context;
      public Handler(SchoolDbContext _context)
      {
        context = _context;
      }
      public async Task<List<Value>> Handle(Query request, CancellationToken cancellationToken)
      {
        var values = await context.Values.ToListAsync();
        return values;
      }
    }
  }
}