namespace StudentManagement.Domain.Countries.Dtos;

using Destructurama.Attributed;

public sealed record CountryDto
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }

}
