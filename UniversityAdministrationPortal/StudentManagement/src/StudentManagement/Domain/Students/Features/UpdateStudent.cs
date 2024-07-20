namespace StudentManagement.Domain.Students.Features;

using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Dtos;
using StudentManagement.Domain.Students.Services;
using StudentManagement.Services;
using StudentManagement.Domain.Students.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateStudent
{
    public sealed record Command(Guid StudentId, StudentForUpdateDto UpdatedStudentData) : IRequest;

    public sealed class Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await studentRepository.GetById(request.StudentId, cancellationToken: cancellationToken);
            var studentToAdd = request.UpdatedStudentData.ToStudentForUpdate();
            studentToUpdate.Update(studentToAdd);

            studentRepository.Update(studentToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}