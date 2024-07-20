namespace StudentManagement.Domain.Genders.Features;

using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.Domain.Genders.Services;
using StudentManagement.Exceptions;
using StudentManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetGenderList
{
    public sealed record Query(GenderParametersDto QueryParameters) : IRequest<PagedList<GenderDto>>;

    public sealed class Handler(IGenderRepository genderRepository)
        : IRequestHandler<Query, PagedList<GenderDto>>
    {
        public async Task<PagedList<GenderDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = genderRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToGenderDtoQueryable();

            return await PagedList<GenderDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}