namespace StudentManagement.Domain.Relationships.Models;

using Destructurama.Attributed;

public sealed record RelationshipForCreation
{
    public string RelationshipName { get; set; }

}
