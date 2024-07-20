namespace StudentManagement.Domain.Genders.Dtos;

using Destructurama.Attributed;

public sealed record GenderDto
{
    public Guid Id { get; set; }
    public string GenderName { get; set; }

}
