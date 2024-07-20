namespace StudentManagement.Domain.Relationships.Features;

using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.Domain.Relationships.Services;
using StudentManagement.Services;
using StudentManagement.Domain.Relationships.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateRelationship
{
    public sealed record Command(Guid RelationshipId, RelationshipForUpdateDto UpdatedRelationshipData) : IRequest;

    public sealed class Handler(IRelationshipRepository relationshipRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var relationshipToUpdate = await relationshipRepository.GetById(request.RelationshipId, cancellationToken: cancellationToken);
            var relationshipToAdd = request.UpdatedRelationshipData.ToRelationshipForUpdate();
            relationshipToUpdate.Update(relationshipToAdd);

            relationshipRepository.Update(relationshipToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}