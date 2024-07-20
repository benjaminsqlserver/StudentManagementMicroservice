namespace StudentManagement.Domain.StudentContactInformations.Features;

using StudentManagement.Domain.StudentContactInformations.Dtos;
using StudentManagement.Domain.StudentContactInformations.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetStudentContactInformation
{
    public sealed record Query(Guid StudentContactInformationId) : IRequest<StudentContactInformationDto>;

    public sealed class Handler(IStudentContactInformationRepository studentContactInformationRepository)
        : IRequestHandler<Query, StudentContactInformationDto>
    {
        public async Task<StudentContactInformationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await studentContactInformationRepository.GetById(request.StudentContactInformationId, cancellationToken: cancellationToken);
            return result.ToStudentContactInformationDto();
        }
    }
}