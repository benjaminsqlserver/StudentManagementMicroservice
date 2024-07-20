namespace StudentManagement.Domain.StudentNextOfKins.Models;

using Destructurama.Attributed;

public sealed record StudentNextOfKinForCreation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid GenderId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid StudentID { get; set; }
    public Guid RelationshipID { get; set; }

}
