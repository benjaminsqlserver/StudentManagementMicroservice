namespace StudentManagement.Domain.Countries.Models;

using Destructurama.Attributed;

public sealed record CountryForCreation
{
    public string CountryName { get; set; }

}
