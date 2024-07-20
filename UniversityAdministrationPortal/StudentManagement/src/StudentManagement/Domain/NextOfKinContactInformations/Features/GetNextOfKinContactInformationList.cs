namespace StudentManagement.Domain.NextOfKinContactInformations.Features;

using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
using StudentManagement.Domain.NextOfKinContactInformations.Services;
using StudentManagement.Exceptions;
using StudentManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetNextOfKinContactInformationList
{
    public sealed record Query(NextOfKinContactInformationParametersDto QueryParameters) : IRequest<PagedList<NextOfKinContactInformationDto>>;

    public sealed class Handler(INextOfKinContactInformationRepository nextOfKinContactInformationRepository)
        : IRequestHandler<Query, PagedList<NextOfKinContactInformationDto>>
    {
        public async Task<PagedList<NextOfKinContactInformationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = nextOfKinContactInformationRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToNextOfKinContactInformationDtoQueryable();

            return await PagedList<NextOfKinContactInformationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}