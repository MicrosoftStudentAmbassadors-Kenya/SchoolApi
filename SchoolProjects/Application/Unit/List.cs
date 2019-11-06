using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Unit = Domain.Unit;

namespace Application.Values
{
  public class UnitList
    {
        public class Query : IRequest<List<Unit>>
        {
            
        }
    public class Handler : IRequestHandler<Query, List<Unit>>
    {
      private readonly SchoolDbContext context;
      public Handler(SchoolDbContext _context)
      {
        context = _context;
      }
      public async Task<List<Unit>> Handle(Query request, CancellationToken cancellationToken)
      {
        var values = await context.Units.ToListAsync();
        return values;
      }
    }
  }
}