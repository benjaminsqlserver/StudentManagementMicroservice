namespace StudentManagement.Domain.StudentNextOfKins.Features;

using StudentManagement.Domain.StudentNextOfKins.Services;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.Domain.StudentNextOfKins.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddStudentNextOfKin
{
    public sealed record Command(StudentNextOfKinForCreationDto StudentNextOfKinToAdd) : IRequest<StudentNextOfKinDto>;

    public sealed class Handler(IStudentNextOfKinRepository studentNextOfKinRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, StudentNextOfKinDto>
    {
        public async Task<StudentNextOfKinDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var studentNextOfKinToAdd = request.StudentNextOfKinToAdd.ToStudentNextOfKinForCreation();
            var studentNextOfKin = StudentNextOfKin.Create(studentNextOfKinToAdd);

            await studentNextOfKinRepository.Add(studentNextOfKin, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return studentNextOfKin.ToStudentNextOfKinDto();
        }
    }
}