namespace StudentManagement.Domain.Countries.Dtos;

using Destructurama.Attributed;

public sealed record CountryForCreationDto
{
    public string CountryName { get; set; }

}
