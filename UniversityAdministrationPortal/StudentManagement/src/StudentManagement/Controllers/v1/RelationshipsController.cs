namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.Relationships.Features;
using StudentManagement.Domain.Relationships.Dtos;
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
[Route("api/v{v:apiVersion}/relationships")]
[ApiVersion("1.0")]
public sealed class RelationshipsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Relationship record.
    /// </summary>
    [HttpPost(Name = "AddRelationship")]
    public async Task<ActionResult<RelationshipDto>> AddRelationship([FromBody]RelationshipForCreationDto relationshipForCreation)
    {
        var command = new AddRelationship.Command(relationshipForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetRelationship",
            new { relationshipId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Relationship by ID.
    /// </summary>
    [HttpGet("{relationshipId:guid}", Name = "GetRelationship")]
    public async Task<ActionResult<RelationshipDto>> GetRelationship(Guid relationshipId)
    {
        var query = new GetRelationship.Query(relationshipId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Relationships.
    /// </summary>
    [HttpGet(Name = "GetRelationships")]
    public async Task<IActionResult> GetRelationships([FromQuery] RelationshipParametersDto relationshipParametersDto)
    {
        var query = new GetRelationshipList.Query(relationshipParametersDto);
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
    /// Updates an entire existing Relationship.
    /// </summary>
    [HttpPut("{relationshipId:guid}", Name = "UpdateRelationship")]
    public async Task<IActionResult> UpdateRelationship(Guid relationshipId, RelationshipForUpdateDto relationship)
    {
        var command = new UpdateRelationship.Command(relationshipId, relationship);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Relationship record.
    /// </summary>
    [HttpDelete("{relationshipId:guid}", Name = "DeleteRelationship")]
    public async Task<ActionResult> DeleteRelationship(Guid relationshipId)
    {
        var command = new DeleteRelationship.Command(relationshipId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
