namespace StudentManagement.Domain.Students.Features;

using StudentManagement.Domain.Students.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteStudent
{
    public sealed record Command(Guid StudentId) : IRequest;

    public sealed class Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await studentRepository.GetById(request.StudentId, cancellationToken: cancellationToken);
            studentRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}