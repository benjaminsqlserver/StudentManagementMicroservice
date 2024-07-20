namespace StudentManagement.Domain.NextOfKinContactInformations.Features;

using StudentManagement.Domain.NextOfKinContactInformations.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteNextOfKinContactInformation
{
    public sealed record Command(Guid NextOfKinContactInformationId) : IRequest;

    public sealed class Handler(INextOfKinContactInformationRepository nextOfKinContactInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await nextOfKinContactInformationRepository.GetById(request.NextOfKinContactInformationId, cancellationToken: cancellationToken);
            nextOfKinContactInformationRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}