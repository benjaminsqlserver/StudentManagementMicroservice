namespace StudentManagement.Domain.Countries.Features;

using StudentManagement.Domain.Countries.Dtos;
using StudentManagement.Domain.Countries.Services;
using StudentManagement.Exceptions;
using StudentManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetCountryList
{
    public sealed record Query(CountryParametersDto QueryParameters) : IRequest<PagedList<CountryDto>>;

    public sealed class Handler(ICountryRepository countryRepository)
        : IRequestHandler<Query, PagedList<CountryDto>>
    {
        public async Task<PagedList<CountryDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = countryRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToCountryDtoQueryable();

            return await PagedList<CountryDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}