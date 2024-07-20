namespace StudentManagement.Domain.StudentContactInformations.Features;

using StudentManagement.Domain.StudentContactInformations.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteStudentContactInformation
{
    public sealed record Command(Guid StudentContactInformationId) : IRequest;

    public sealed class Handler(IStudentContactInformationRepository studentContactInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await studentContactInformationRepository.GetById(request.StudentContactInformationId, cancellationToken: cancellationToken);
            studentContactInformationRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}