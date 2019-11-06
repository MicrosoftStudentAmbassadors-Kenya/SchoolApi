using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Values;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {

    private readonly IMediator _mediator;
    public ValuesController(IMediator mediator)
    {
      _mediator = mediator;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Value>>> Get()
    {
      var values = await _mediator.Send(new List.Query());
      return Ok(values);

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Value>> Get(int id)
    {
      var value= await _mediator.Send(new Details.Query { Id = id });
      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Value value)
    {
      var result = await _mediator.Send(new Create.Command() { Id = value.Id, Name = value.Name });
      return Ok(result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Value value)
    {
      var result = await _mediator.Send(new Update.Command { Id = value.Id, Name = value.Name });
      if(result ==null) return Ok(result);
      return NotFound();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _mediator.Send(new Delete.Command { Id = id });
      return Ok(result);
    }
  }
}
