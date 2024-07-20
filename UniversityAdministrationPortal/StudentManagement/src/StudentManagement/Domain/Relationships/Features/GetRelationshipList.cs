namespace StudentManagement.Domain.Relationships.Features;

using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.Domain.Relationships.Services;
using StudentManagement.Exceptions;
using StudentManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetRelationshipList
{
    public sealed record Query(RelationshipParametersDto QueryParameters) : IRequest<PagedList<RelationshipDto>>;

    public sealed class Handler(IRelationshipRepository relationshipRepository)
        : IRequestHandler<Query, PagedList<RelationshipDto>>
    {
        public async Task<PagedList<RelationshipDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = relationshipRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToRelationshipDtoQueryable();

            return await PagedList<RelationshipDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}