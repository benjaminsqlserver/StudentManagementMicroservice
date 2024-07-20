namespace StudentManagement.Domain.Genders.Features;

using StudentManagement.Domain.Genders.Services;
using StudentManagement.Services;
using StudentManagement.Exceptions;
using MediatR;

public static class DeleteGender
{
    public sealed record Command(Guid GenderId) : IRequest;

    public sealed class Handler(IGenderRepository genderRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await genderRepository.GetById(request.GenderId, cancellationToken: cancellationToken);
            genderRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}