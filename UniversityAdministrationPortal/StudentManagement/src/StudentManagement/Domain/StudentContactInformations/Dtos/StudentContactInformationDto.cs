namespace StudentManagement.Domain.StudentContactInformations.Dtos;

using Destructurama.Attributed;

public sealed record StudentContactInformationDto
{
    public Guid Id { get; set; }
    public string HouseAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public Guid CountryID { get; set; }
    public Guid StudentID { get; set; }
}
