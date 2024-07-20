namespace StudentManagement.Domain.Relationships.Dtos;

using Destructurama.Attributed;

public sealed record RelationshipDto
{
    public Guid Id { get; set; }
    public string RelationshipName { get; set; }

}
