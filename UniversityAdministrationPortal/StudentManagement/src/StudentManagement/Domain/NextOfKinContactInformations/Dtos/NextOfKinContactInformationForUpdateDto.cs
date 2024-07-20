namespace StudentManagement.Domain.NextOfKinContactInformations.Dtos;

using Destructurama.Attributed;

public sealed record NextOfKinContactInformationForUpdateDto
{
    public string HouseAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public Guid CountryID { get; set; }
    public Guid NextOfKinID { get; set; }
}
