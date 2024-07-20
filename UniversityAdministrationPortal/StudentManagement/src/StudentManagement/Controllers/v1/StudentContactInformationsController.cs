namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.StudentContactInformations.Features;
using StudentManagement.Domain.StudentContactInformations.Dtos;
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
[Route("api/v{v:apiVersion}/studentcontactinformations")]
[ApiVersion("1.0")]
public sealed class StudentContactInformationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new StudentContactInformation record.
    /// </summary>
    [HttpPost(Name = "AddStudentContactInformation")]
    public async Task<ActionResult<StudentContactInformationDto>> AddStudentContactInformation([FromBody]StudentContactInformationForCreationDto studentContactInformationForCreation)
    {
        var command = new AddStudentContactInformation.Command(studentContactInformationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetStudentContactInformation",
            new { studentContactInformationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single StudentContactInformation by ID.
    /// </summary>
    [HttpGet("{studentContactInformationId:guid}", Name = "GetStudentContactInformation")]
    public async Task<ActionResult<StudentContactInformationDto>> GetStudentContactInformation(Guid studentContactInformationId)
    {
        var query = new GetStudentContactInformation.Query(studentContactInformationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all StudentContactInformations.
    /// </summary>
    [HttpGet(Name = "GetStudentContactInformations")]
    public async Task<IActionResult> GetStudentContactInformations([FromQuery] StudentContactInformationParametersDto studentContactInformationParametersDto)
    {
        var query = new GetStudentContactInformationList.Query(studentContactInformationParametersDto);
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
    /// Updates an entire existing StudentContactInformation.
    /// </summary>
    [HttpPut("{studentContactInformationId:guid}", Name = "UpdateStudentContactInformation")]
    public async Task<IActionResult> UpdateStudentContactInformation(Guid studentContactInformationId, StudentContactInformationForUpdateDto studentContactInformation)
    {
        var command = new UpdateStudentContactInformation.Command(studentContactInformationId, studentContactInformation);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing StudentContactInformation record.
    /// </summary>
    [HttpDelete("{studentContactInformationId:guid}", Name = "DeleteStudentContactInformation")]
    public async Task<ActionResult> DeleteStudentContactInformation(Guid studentContactInformationId)
    {
        var command = new DeleteStudentContactInformation.Command(studentContactInformationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
