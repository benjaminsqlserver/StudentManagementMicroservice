namespace StudentManagement.Domain.Countries.Features;

using StudentManagement.Domain.Countries.Services;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.Dtos;
using StudentManagement.Domain.Countries.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddCountry
{
    public sealed record Command(CountryForCreationDto CountryToAdd) : IRequest<CountryDto>;

    public sealed class Handler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, CountryDto>
    {
        public async Task<CountryDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var countryToAdd = request.CountryToAdd.ToCountryForCreation();
            var country = Country.Create(countryToAdd);

            await countryRepository.Add(country, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return country.ToCountryDto();
        }
    }
}