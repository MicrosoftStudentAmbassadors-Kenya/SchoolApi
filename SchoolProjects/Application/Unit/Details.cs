using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Unit = Domain.Unit;

namespace Application.Values
{
  public class UnitDetails 
    {
        public class Query : IRequest<Unit>
        {
          public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Unit>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
      
      public Task<Unit> Handle(Query request, CancellationToken cancellationToken)
      {
        var value = _context.Units.FindAsync(request.Id);
        return value;
      }
    }

  }
}