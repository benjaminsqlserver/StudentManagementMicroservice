namespace StudentManagement.Domain.Genders.Features;

using StudentManagement.Domain.Genders.Services;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.Domain.Genders.Models;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddGender
{
    public sealed record Command(GenderForCreationDto GenderToAdd) : IRequest<GenderDto>;

    public sealed class Handler(IGenderRepository genderRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, GenderDto>
    {
        public async Task<GenderDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var genderToAdd = request.GenderToAdd.ToGenderForCreation();
            var gender = Gender.Create(genderToAdd);

            await genderRepository.Add(gender, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return gender.ToGenderDto();
        }
    }
}