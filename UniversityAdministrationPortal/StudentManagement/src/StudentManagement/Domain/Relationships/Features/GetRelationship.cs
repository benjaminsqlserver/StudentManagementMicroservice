namespace StudentManagement.Domain.Relationships.Features;

using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.Domain.Relationships.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetRelationship
{
    public sealed record Query(Guid RelationshipId) : IRequest<RelationshipDto>;

    public sealed class Handler(IRelationshipRepository relationshipRepository)
        : IRequestHandler<Query, RelationshipDto>
    {
        public async Task<RelationshipDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await relationshipRepository.GetById(request.RelationshipId, cancellationToken: cancellationToken);
            return result.ToRelationshipDto();
        }
    }
}