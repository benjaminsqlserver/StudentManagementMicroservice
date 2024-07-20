namespace StudentManagement.Domain.StudentContactInformations.Features;

using StudentManagement.Domain.StudentContactInformations.Services;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Dtos;
using StudentManagement.Domain.StudentContactInformations.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddStudentContactInformation
{
    public sealed record Command(StudentContactInformationForCreationDto StudentContactInformationToAdd) : IRequest<StudentContactInformationDto>;

    public sealed class Handler(IStudentContactInformationRepository studentContactInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, StudentContactInformationDto>
    {
        public async Task<StudentContactInformationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var studentContactInformationToAdd = request.StudentContactInformationToAdd.ToStudentContactInformationForCreation();
            var studentContactInformation = StudentContactInformation.Create(studentContactInformationToAdd);

            await studentContactInformationRepository.Add(studentContactInformation, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return studentContactInformation.ToStudentContactInformationDto();
        }
    }
}