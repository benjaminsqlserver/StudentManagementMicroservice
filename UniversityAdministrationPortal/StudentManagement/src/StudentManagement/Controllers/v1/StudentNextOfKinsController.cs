namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.StudentNextOfKins.Features;
using StudentManagement.Domain.StudentNextOfKins.Dtos;
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
[Route("api/v{v:apiVersion}/studentnextofkins")]
[ApiVersion("1.0")]
public sealed class StudentNextOfKinsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new StudentNextOfKin record.
    /// </summary>
    [HttpPost(Name = "AddStudentNextOfKin")]
    public async Task<ActionResult<StudentNextOfKinDto>> AddStudentNextOfKin([FromBody]StudentNextOfKinForCreationDto studentNextOfKinForCreation)
    {
        var command = new AddStudentNextOfKin.Command(studentNextOfKinForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetStudentNextOfKin",
            new { studentNextOfKinId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single StudentNextOfKin by ID.
    /// </summary>
    [HttpGet("{studentNextOfKinId:guid}", Name = "GetStudentNextOfKin")]
    public async Task<ActionResult<StudentNextOfKinDto>> GetStudentNextOfKin(Guid studentNextOfKinId)
    {
        var query = new GetStudentNextOfKin.Query(studentNextOfKinId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all StudentNextOfKins.
    /// </summary>
    [HttpGet(Name = "GetStudentNextOfKins")]
    public async Task<IActionResult> GetStudentNextOfKins([FromQuery] StudentNextOfKinParametersDto studentNextOfKinParametersDto)
    {
        var query = new GetStudentNextOfKinList.Query(studentNextOfKinParametersDto);
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
    /// Updates an entire existing StudentNextOfKin.
    /// </summary>
    [HttpPut("{studentNextOfKinId:guid}", Name = "UpdateStudentNextOfKin")]
    public async Task<IActionResult> UpdateStudentNextOfKin(Guid studentNextOfKinId, StudentNextOfKinForUpdateDto studentNextOfKin)
    {
        var command = new UpdateStudentNextOfKin.Command(studentNextOfKinId, studentNextOfKin);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing StudentNextOfKin record.
    /// </summary>
    [HttpDelete("{studentNextOfKinId:guid}", Name = "DeleteStudentNextOfKin")]
    public async Task<ActionResult> DeleteStudentNextOfKin(Guid studentNextOfKinId)
    {
        var command = new DeleteStudentNextOfKin.Command(studentNextOfKinId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
