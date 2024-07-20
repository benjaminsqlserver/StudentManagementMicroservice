namespace StudentManagement.Domain.StudentNextOfKins.Features;

using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.Domain.StudentNextOfKins.Services;
using StudentManagement.Services;
using StudentManagement.Domain.StudentNextOfKins.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateStudentNextOfKin
{
    public sealed record Command(Guid StudentNextOfKinId, StudentNextOfKinForUpdateDto UpdatedStudentNextOfKinData) : IRequest;

    public sealed class Handler(IStudentNextOfKinRepository studentNextOfKinRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var studentNextOfKinToUpdate = await studentNextOfKinRepository.GetById(request.StudentNextOfKinId, cancellationToken: cancellationToken);
            var studentNextOfKinToAdd = request.UpdatedStudentNextOfKinData.ToStudentNextOfKinForUpdate();
            studentNextOfKinToUpdate.Update(studentNextOfKinToAdd);

            studentNextOfKinRepository.Update(studentNextOfKinToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}