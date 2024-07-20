namespace StudentManagement.Domain.Countries.Features;

using StudentManagement.Domain.Countries.Dtos;
using StudentManagement.Domain.Countries.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetCountry
{
    public sealed record Query(Guid CountryId) : IRequest<CountryDto>;

    public sealed class Handler(ICountryRepository countryRepository)
        : IRequestHandler<Query, CountryDto>
    {
        public async Task<CountryDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await countryRepository.GetById(request.CountryId, cancellationToken: cancellationToken);
            return result.ToCountryDto();
        }
    }
}