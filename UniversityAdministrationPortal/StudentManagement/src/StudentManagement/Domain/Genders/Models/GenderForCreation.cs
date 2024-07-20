namespace StudentManagement.Domain.Genders.Models;

using Destructurama.Attributed;

public sealed record GenderForCreation
{
    public string GenderName { get; set; }

}
