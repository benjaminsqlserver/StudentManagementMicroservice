namespace StudentManagement.Domain.Genders.Features;

using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.Domain.Genders.Services;
using StudentManagement.Services;
using StudentManagement.Domain.Genders.Models;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateGender
{
    public sealed record Command(Guid GenderId, GenderForUpdateDto UpdatedGenderData) : IRequest;

    public sealed class Handler(IGenderRepository genderRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var genderToUpdate = await genderRepository.GetById(request.GenderId, cancellationToken: cancellationToken);
            var genderToAdd = request.UpdatedGenderData.ToGenderForUpdate();
            genderToUpdate.Update(genderToAdd);

            genderRepository.Update(genderToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}