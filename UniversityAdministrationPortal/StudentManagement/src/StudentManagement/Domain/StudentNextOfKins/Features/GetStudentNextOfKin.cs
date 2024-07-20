namespace StudentManagement.Domain.StudentNextOfKins.Features;

using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.Domain.StudentNextOfKins.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetStudentNextOfKin
{
    public sealed record Query(Guid StudentNextOfKinId) : IRequest<StudentNextOfKinDto>;

    public sealed class Handler(IStudentNextOfKinRepository studentNextOfKinRepository)
        : IRequestHandler<Query, StudentNextOfKinDto>
    {
        public async Task<StudentNextOfKinDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await studentNextOfKinRepository.GetById(request.StudentNextOfKinId, cancellationToken: cancellationToken);
            return result.ToStudentNextOfKinDto();
        }
    }
}