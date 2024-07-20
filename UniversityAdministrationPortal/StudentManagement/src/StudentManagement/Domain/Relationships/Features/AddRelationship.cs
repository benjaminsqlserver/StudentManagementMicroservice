namespace StudentManagement.Domain.Relationships.Features;

using StudentManagement.Domain.Relationships.Services;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.Domain.Relationships.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddRelationship
{
    public sealed record Command(RelationshipForCreationDto RelationshipToAdd) : IRequest<RelationshipDto>;

    public sealed class Handler(IRelationshipRepository relationshipRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, RelationshipDto>
    {
        public async Task<RelationshipDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var relationshipToAdd = request.RelationshipToAdd.ToRelationshipForCreation();
            var relationship = Relationship.Create(relationshipToAdd);

            await relationshipRepository.Add(relationship, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return relationship.ToRelationshipDto();
        }
    }
}