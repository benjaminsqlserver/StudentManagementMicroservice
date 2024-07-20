namespace StudentManagement.Domain.NextOfKinContactInformations.Features;

using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
using StudentManagement.Domain.NextOfKinContactInformations.Services;
using StudentManagement.Services;
using StudentManagement.Domain.NextOfKinContactInformations.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateNextOfKinContactInformation
{
    public sealed record Command(Guid NextOfKinContactInformationId, NextOfKinContactInformationForUpdateDto UpdatedNextOfKinContactInformationData) : IRequest;

    public sealed class Handler(INextOfKinContactInformationRepository nextOfKinContactInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var nextOfKinContactInformationToUpdate = await nextOfKinContactInformationRepository.GetById(request.NextOfKinContactInformationId, cancellationToken: cancellationToken);
            var nextOfKinContactInformationToAdd = request.UpdatedNextOfKinContactInformationData.ToNextOfKinContactInformationForUpdate();
            nextOfKinContactInformationToUpdate.Update(nextOfKinContactInformationToAdd);

            nextOfKinContactInformationRepository.Update(nextOfKinContactInformationToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}