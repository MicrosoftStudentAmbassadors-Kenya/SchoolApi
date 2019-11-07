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
  public class CourseController : ControllerBase
  {

    private readonly IMediator _mediator;
    public CourseController(IMediator mediator)
    {
      _mediator = mediator;
    }
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Value>>> Get()
    {
      var values = await _mediator.Send(new ListCourses.Query());
      return Ok(values);

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Value>> Get(int id)
    {
      var value= await _mediator.Send(new DetailsCourse.Query(){Id=id});
      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Course value)
    {
      var result = await _mediator.Send(new CreateCourse.Command{ CourseName=value.CourseName,NumberofYears=value.NumberofYears,NumberOfUnits= value.NumberofUnits });
      return Ok(result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Course value)
    {
      if(id!=value.CourseId) return BadRequest(ModelState);
      var result = await _mediator.Send(new UpdateCourse.Command{Id=id,CourseName=value.CourseName,NumberOfUnits=value.NumberofUnits,NumberofYears=value.NumberofYears});
      if(result ==null) return Ok(result);
      return NotFound();

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _mediator.Send(new DeleteCourse.Command{Id=id});
      return Ok(result);
    }
  }
}
