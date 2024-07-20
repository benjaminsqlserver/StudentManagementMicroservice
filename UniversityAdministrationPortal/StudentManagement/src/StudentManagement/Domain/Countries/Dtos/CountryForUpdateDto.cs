namespace StudentManagement.Domain.Countries.Dtos;

using Destructurama.Attributed;

public sealed record CountryForUpdateDto
{
    public string CountryName { get; set; }

}
