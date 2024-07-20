namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.Genders.Features;
using StudentManagement.Domain.Genders.Dtos;
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
[Route("api/v{v:apiVersion}/genders")]
[ApiVersion("1.0")]
public sealed class GendersController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Gender record.
    /// </summary>
    [HttpPost(Name = "AddGender")]
    public async Task<ActionResult<GenderDto>> AddGender([FromBody]GenderForCreationDto genderForCreation)
    {
        var command = new AddGender.Command(genderForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetGender",
            new { genderId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Gender by ID.
    /// </summary>
    [HttpGet("{genderId:guid}", Name = "GetGender")]
    public async Task<ActionResult<GenderDto>> GetGender(Guid genderId)
    {
        var query = new GetGender.Query(genderId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Genders.
    /// </summary>
    [HttpGet(Name = "GetGenders")]
    public async Task<IActionResult> GetGenders([FromQuery] GenderParametersDto genderParametersDto)
    {
        var query = new GetGenderList.Query(genderParametersDto);
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
    /// Updates an entire existing Gender.
    /// </summary>
    [HttpPut("{genderId:guid}", Name = "UpdateGender")]
    public async Task<IActionResult> UpdateGender(Guid genderId, GenderForUpdateDto gender)
    {
        var command = new UpdateGender.Command(genderId, gender);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Gender record.
    /// </summary>
    [HttpDelete("{genderId:guid}", Name = "DeleteGender")]
    public async Task<ActionResult> DeleteGender(Guid genderId)
    {
        var command = new DeleteGender.Command(genderId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
