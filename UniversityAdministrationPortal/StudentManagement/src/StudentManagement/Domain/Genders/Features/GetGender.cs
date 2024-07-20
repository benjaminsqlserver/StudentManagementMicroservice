namespace StudentManagement.Domain.Genders.Features;

using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.Domain.Genders.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetGender
{
    public sealed record Query(Guid GenderId) : IRequest<GenderDto>;

    public sealed class Handler(IGenderRepository genderRepository)
        : IRequestHandler<Query, GenderDto>
    {
        public async Task<GenderDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await genderRepository.GetById(request.GenderId, cancellationToken: cancellationToken);
            return result.ToGenderDto();
        }
    }
}