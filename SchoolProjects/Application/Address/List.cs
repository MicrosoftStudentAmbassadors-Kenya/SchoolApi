using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Values
{
  public class ListAddress
  {
    public class Query : IRequest<List<Address>>
    {

    }
    public class Handler : IRequestHandler<Query, List<Address>>
    {
      private readonly SchoolDbContext context;
      public Handler(SchoolDbContext _context)
      {
        context = _context;
      }
      public async Task<List<Address>> Handle(Query request, CancellationToken cancellationToken)
      {
        var values = await context.Addresses.ToListAsync();
        return values;
      }
    }
  }
}