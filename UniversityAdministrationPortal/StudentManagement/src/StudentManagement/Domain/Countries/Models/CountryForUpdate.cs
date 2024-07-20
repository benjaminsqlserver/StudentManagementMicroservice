namespace StudentManagement.Domain.Countries.Models;

using Destructurama.Attributed;

public sealed record CountryForUpdate
{
    public string CountryName { get; set; }

}
