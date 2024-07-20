namespace StudentManagement.Domain.Relationships.Dtos;

using Destructurama.Attributed;

public sealed record RelationshipForCreationDto
{
    public string RelationshipName { get; set; }

}
