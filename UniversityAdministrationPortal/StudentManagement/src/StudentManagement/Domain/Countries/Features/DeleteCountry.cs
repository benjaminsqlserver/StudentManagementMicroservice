namespace StudentManagement.Domain.Countries.Features;

using StudentManagement.Domain.Countries.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteCountry
{
    public sealed record Command(Guid CountryId) : IRequest;

    public sealed class Handler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await countryRepository.GetById(request.CountryId, cancellationToken: cancellationToken);
            countryRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}