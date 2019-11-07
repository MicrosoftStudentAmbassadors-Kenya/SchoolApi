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
  public class ClassroomsController : ControllerBase
  {

    private readonly IMediator _mediator;
    public ClassroomsController(IMediator mediator)
    {
      _mediator = mediator;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Classroom>>> Get()
    {
      var values = await _mediator.Send(new ListClassRooms.Query());
      return Ok(values);

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Classroom>> Get(int id)
    {
      var value= await _mediator.Send(new ClassroomDetails.Query(){Id=id});
      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Classroom value)
    {
      var result = await _mediator.Send(new CreateClassroom.Command(){Name= value.ClassroomName});
      return Ok(result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Classroom value)
    {
      var result = await _mediator.Send(new UpdateClassroom.Command{Id=id,Name=value.ClassroomName});
      if(result ==null) return Ok(result);
      return NotFound();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _mediator.Send(new DeleteClassroom.Command{Id = id});
      return Ok(result);
    }
  }
}
