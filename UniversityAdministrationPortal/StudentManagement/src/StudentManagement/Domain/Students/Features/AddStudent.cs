namespace StudentManagement.Domain.Students.Features;

using StudentManagement.Domain.Students.Services;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Dtos;
using StudentManagement.Domain.Students.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddStudent
{
    public sealed record Command(StudentForCreationDto StudentToAdd) : IRequest<StudentDto>;

    public sealed class Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, StudentDto>
    {
        public async Task<StudentDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var studentToAdd = request.StudentToAdd.ToStudentForCreation();
            var student = Student.Create(studentToAdd);

            await studentRepository.Add(student, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return student.ToStudentDto();
        }
    }
}