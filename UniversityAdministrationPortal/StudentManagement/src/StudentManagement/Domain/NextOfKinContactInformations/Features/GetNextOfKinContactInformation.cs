namespace StudentManagement.Domain.NextOfKinContactInformations.Features;

using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
using StudentManagement.Domain.NextOfKinContactInformations.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetNextOfKinContactInformation
{
    public sealed record Query(Guid NextOfKinContactInformationId) : IRequest<NextOfKinContactInformationDto>;

    public sealed class Handler(INextOfKinContactInformationRepository nextOfKinContactInformationRepository)
        : IRequestHandler<Query, NextOfKinContactInformationDto>
    {
        public async Task<NextOfKinContactInformationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await nextOfKinContactInformationRepository.GetById(request.NextOfKinContactInformationId, cancellationToken: cancellationToken);
            return result.ToNextOfKinContactInformationDto();
        }
    }
}