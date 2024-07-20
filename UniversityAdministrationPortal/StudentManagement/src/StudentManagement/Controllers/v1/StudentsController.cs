namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.Students.Features;
using StudentManagement.Domain.Students.Dtos;
using StudentManagement.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/students")]
[ApiVersion("1.0")]
public sealed class StudentsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Student record.
    /// </summary>
    [HttpPost(Name = "AddStudent")]
    public async Task<ActionResult<StudentDto>> AddStudent([FromBody]StudentForCreationDto studentForCreation)
    {
        var command = new AddStudent.Command(studentForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetStudent",
            new { studentId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Student by ID.
    /// </summary>
    [HttpGet("{studentId:guid}", Name = "GetStudent")]
    public async Task<ActionResult<StudentDto>> GetStudent(Guid studentId)
    {
        var query = new GetStudent.Query(studentId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Students.
    /// </summary>
    [HttpGet(Name = "GetStudents")]
    public async Task<IActionResult> GetStudents([FromQuery] StudentParametersDto studentParametersDto)
    {
        var query = new GetStudentList.Query(studentParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing Student.
    /// </summary>
    [HttpPut("{studentId:guid}", Name = "UpdateStudent")]
    public async Task<IActionResult> UpdateStudent(Guid studentId, StudentForUpdateDto student)
    {
        var command = new UpdateStudent.Command(studentId, student);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Student record.
    /// </summary>
    [HttpDelete("{studentId:guid}", Name = "DeleteStudent")]
    public async Task<ActionResult> DeleteStudent(Guid studentId)
    {
        var command = new DeleteStudent.Command(studentId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
