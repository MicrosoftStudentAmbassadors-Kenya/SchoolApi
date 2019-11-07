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
  public class StudentsController : ControllerBase
  {

    private readonly IMediator _mediator;
    public StudentsController(IMediator mediator)
    {
      _mediator = mediator;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> Get()
    {
      var values = await _mediator.Send(new StudentList.Query());
      return Ok(values);

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Value>> Get(int id)
    {
      var value= await _mediator.Send(new StudentDetails.Query { Id = id });
      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Student value)
    {
      var result = await _mediator.Send(new CreateStudent.Command{ FirstName = value.FirstName,LastName=value.LastName,PhoneNumber = value.PhoneNumber,Age=value.Age});
      return Ok(result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Student value)
    {
      var result = await _mediator.Send(new UpdateStudent.Command { Id = value.StudentId,FirstName = value.FirstName,LastName=value.LastName,PhoneNumber = value.PhoneNumber,Age=value.Age});
      if(result ==null) return Ok(result);
      return NotFound();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _mediator.Send(new DeleteStudent.Command(){Id=id});
      return Ok(result);
    } 
  }
}
