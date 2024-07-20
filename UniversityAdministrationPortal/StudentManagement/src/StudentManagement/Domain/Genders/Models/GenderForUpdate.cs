namespace StudentManagement.Domain.Genders.Models;

using Destructurama.Attributed;

public sealed record GenderForUpdate
{
    public string GenderName { get; set; }

}
