namespace StudentManagement.Domain.Genders.Dtos;

using Destructurama.Attributed;

public sealed record GenderForUpdateDto
{
    public string GenderName { get; set; }

}
