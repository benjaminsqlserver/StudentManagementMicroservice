namespace StudentManagement.Domain.Genders.Dtos;

using Destructurama.Attributed;

public sealed record GenderForCreationDto
{
    public string GenderName { get; set; }

}
