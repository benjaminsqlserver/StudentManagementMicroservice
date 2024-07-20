namespace StudentManagement.Domain.StudentContactInformations.Features;

using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Dtos;
using StudentManagement.Domain.StudentContactInformations.Services;
using StudentManagement.Services;
using StudentManagement.Domain.StudentContactInformations.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateStudentContactInformation
{
    public sealed record Command(Guid StudentContactInformationId, StudentContactInformationForUpdateDto UpdatedStudentContactInformationData) : IRequest;

    public sealed class Handler(IStudentContactInformationRepository studentContactInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var studentContactInformationToUpdate = await studentContactInformationRepository.GetById(request.StudentContactInformationId, cancellationToken: cancellationToken);
            var studentContactInformationToAdd = request.UpdatedStudentContactInformationData.ToStudentContactInformationForUpdate();
            studentContactInformationToUpdate.Update(studentContactInformationToAdd);

            studentContactInformationRepository.Update(studentContactInformationToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}