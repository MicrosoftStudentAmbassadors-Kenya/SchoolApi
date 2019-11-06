using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Values
{
  public class Details 
    {
        public class Query : IRequest<Value>
        {
          public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Value>
    {
      private readonly SchoolDbContext _context;

      public Handler(SchoolDbContext context)
      {
        _context = context;
      }
      
      public Task<Value> Handle(Query request, CancellationToken cancellationToken)
      {
        var value = _context.Values.FindAsync(request.Id);
        return value;
      }
    }

  }
}