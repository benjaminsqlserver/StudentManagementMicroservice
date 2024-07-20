namespace StudentManagement.Domain.Countries.Features;

using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.Dtos;
using StudentManagement.Domain.Countries.Services;
using StudentManagement.Services;
using StudentManagement.Domain.Countries.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateCountry
{
    public sealed record Command(Guid CountryId, CountryForUpdateDto UpdatedCountryData) : IRequest;

    public sealed class Handler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var countryToUpdate = await countryRepository.GetById(request.CountryId, cancellationToken: cancellationToken);
            var countryToAdd = request.UpdatedCountryData.ToCountryForUpdate();
            countryToUpdate.Update(countryToAdd);

            countryRepository.Update(countryToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}