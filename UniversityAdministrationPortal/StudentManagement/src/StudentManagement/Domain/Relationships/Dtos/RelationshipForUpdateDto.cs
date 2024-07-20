namespace StudentManagement.Domain.Relationships.Dtos;

using Destructurama.Attributed;

public sealed record RelationshipForUpdateDto
{
    public string RelationshipName { get; set; }

}
