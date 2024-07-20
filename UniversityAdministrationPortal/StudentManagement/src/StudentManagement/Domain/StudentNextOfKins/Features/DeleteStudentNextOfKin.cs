namespace StudentManagement.Domain.StudentNextOfKins.Features;

using StudentManagement.Domain.StudentNextOfKins.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteStudentNextOfKin
{
    public sealed record Command(Guid StudentNextOfKinId) : IRequest;

    public sealed class Handler(IStudentNextOfKinRepository studentNextOfKinRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await studentNextOfKinRepository.GetById(request.StudentNextOfKinId, cancellationToken: cancellationToken);
            studentNextOfKinRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}