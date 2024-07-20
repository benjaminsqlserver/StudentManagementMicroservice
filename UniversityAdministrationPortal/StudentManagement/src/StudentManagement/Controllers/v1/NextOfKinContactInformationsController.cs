namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.NextOfKinContactInformations.Features;
using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
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
[Route("api/v{v:apiVersion}/nextofkincontactinformations")]
[ApiVersion("1.0")]
public sealed class NextOfKinContactInformationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new NextOfKinContactInformation record.
    /// </summary>
    [HttpPost(Name = "AddNextOfKinContactInformation")]
    public async Task<ActionResult<NextOfKinContactInformationDto>> AddNextOfKinContactInformation([FromBody]NextOfKinContactInformationForCreationDto nextOfKinContactInformationForCreation)
    {
        var command = new AddNextOfKinContactInformation.Command(nextOfKinContactInformationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetNextOfKinContactInformation",
            new { nextOfKinContactInformationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single NextOfKinContactInformation by ID.
    /// </summary>
    [HttpGet("{nextOfKinContactInformationId:guid}", Name = "GetNextOfKinContactInformation")]
    public async Task<ActionResult<NextOfKinContactInformationDto>> GetNextOfKinContactInformation(Guid nextOfKinContactInformationId)
    {
        var query = new GetNextOfKinContactInformation.Query(nextOfKinContactInformationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all NextOfKinContactInformations.
    /// </summary>
    [HttpGet(Name = "GetNextOfKinContactInformations")]
    public async Task<IActionResult> GetNextOfKinContactInformations([FromQuery] NextOfKinContactInformationParametersDto nextOfKinContactInformationParametersDto)
    {
        var query = new GetNextOfKinContactInformationList.Query(nextOfKinContactInformationParametersDto);
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
    /// Updates an entire existing NextOfKinContactInformation.
    /// </summary>
    [HttpPut("{nextOfKinContactInformationId:guid}", Name = "UpdateNextOfKinContactInformation")]
    public async Task<IActionResult> UpdateNextOfKinContactInformation(Guid nextOfKinContactInformationId, NextOfKinContactInformationForUpdateDto nextOfKinContactInformation)
    {
        var command = new UpdateNextOfKinContactInformation.Command(nextOfKinContactInformationId, nextOfKinContactInformation);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing NextOfKinContactInformation record.
    /// </summary>
    [HttpDelete("{nextOfKinContactInformationId:guid}", Name = "DeleteNextOfKinContactInformation")]
    public async Task<ActionResult> DeleteNextOfKinContactInformation(Guid nextOfKinContactInformationId)
    {
        var command = new DeleteNextOfKinContactInformation.Command(nextOfKinContactInformationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
