namespace StudentManagement.Controllers.v1;

using StudentManagement.Domain.Countries.Features;
using StudentManagement.Domain.Countries.Dtos;
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
[Route("api/v{v:apiVersion}/countries")]
[ApiVersion("1.0")]
public sealed class CountriesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Country record.
    /// </summary>
    [HttpPost(Name = "AddCountry")]
    public async Task<ActionResult<CountryDto>> AddCountry([FromBody]CountryForCreationDto countryForCreation)
    {
        var command = new AddCountry.Command(countryForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetCountry",
            new { countryId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Country by ID.
    /// </summary>
    [HttpGet("{countryId:guid}", Name = "GetCountry")]
    public async Task<ActionResult<CountryDto>> GetCountry(Guid countryId)
    {
        var query = new GetCountry.Query(countryId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Countries.
    /// </summary>
    [HttpGet(Name = "GetCountries")]
    public async Task<IActionResult> GetCountries([FromQuery] CountryParametersDto countryParametersDto)
    {
        var query = new GetCountryList.Query(countryParametersDto);
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
    /// Updates an entire existing Country.
    /// </summary>
    [HttpPut("{countryId:guid}", Name = "UpdateCountry")]
    public async Task<IActionResult> UpdateCountry(Guid countryId, CountryForUpdateDto country)
    {
        var command = new UpdateCountry.Command(countryId, country);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Country record.
    /// </summary>
    [HttpDelete("{countryId:guid}", Name = "DeleteCountry")]
    public async Task<ActionResult> DeleteCountry(Guid countryId)
    {
        var command = new DeleteCountry.Command(countryId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
