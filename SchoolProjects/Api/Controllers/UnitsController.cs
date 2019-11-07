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
  public class UnitsController : ControllerBase
  {

    private readonly IMediator _mediator;
    public UnitsController(IMediator mediator)
    {
      _mediator = mediator;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.Unit>>> Get()
    {
      var values = await _mediator.Send(new UnitList.Query());
      return Ok(values);

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Domain.Unit>> Get(int id)
    {
      var value= await _mediator.Send(new UnitDetails.Query{Id=id});
      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Domain.Unit value)
    {
      var result = await _mediator.Send(new CreateUnit.Command{UnitName=value.UnitName,Description=value.Description,HasLab=value.HasLab});
      return Ok(result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Domain.Unit value)
    {
      var result = await _mediator.Send(new UpdateUnit.Command{UnitName=value.UnitName,Description=value.Description,HasLab=value.HasLab} );
      if(result ==null) return Ok(result);
      return NotFound();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _mediator.Send(new DeleteUnit
      .Command { Id = id });
      return Ok(result);
    }
  }
}
