namespace StudentManagement.Domain.Relationships.Features;

using StudentManagement.Domain.Relationships.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteRelationship
{
    public sealed record Command(Guid RelationshipId) : IRequest;

    public sealed class Handler(IRelationshipRepository relationshipRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await relationshipRepository.GetById(request.RelationshipId, cancellationToken: cancellationToken);
            relationshipRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}