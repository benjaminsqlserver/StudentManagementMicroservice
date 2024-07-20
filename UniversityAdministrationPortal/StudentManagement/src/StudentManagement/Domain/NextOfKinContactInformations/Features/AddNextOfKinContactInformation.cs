namespace StudentManagement.Domain.NextOfKinContactInformations.Features;

using StudentManagement.Domain.NextOfKinContactInformations.Services;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
using StudentManagement.Domain.NextOfKinContactInformations.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddNextOfKinContactInformation
{
    public sealed record Command(NextOfKinContactInformationForCreationDto NextOfKinContactInformationToAdd) : IRequest<NextOfKinContactInformationDto>;

    public sealed class Handler(INextOfKinContactInformationRepository nextOfKinContactInformationRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, NextOfKinContactInformationDto>
    {
        public async Task<NextOfKinContactInformationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var nextOfKinContactInformationToAdd = request.NextOfKinContactInformationToAdd.ToNextOfKinContactInformationForCreation();
            var nextOfKinContactInformation = NextOfKinContactInformation.Create(nextOfKinContactInformationToAdd);

            await nextOfKinContactInformationRepository.Add(nextOfKinContactInformation, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return nextOfKinContactInformation.ToNextOfKinContactInformationDto();
        }
    }
}