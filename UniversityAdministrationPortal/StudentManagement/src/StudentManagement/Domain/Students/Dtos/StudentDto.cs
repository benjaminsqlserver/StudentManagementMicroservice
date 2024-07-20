namespace StudentManagement.Domain.Students.Dtos;

using Destructurama.Attributed;

public sealed record StudentDto
{
    public Guid Id { get; set; }
    public string MatriculationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid GenderId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

}
