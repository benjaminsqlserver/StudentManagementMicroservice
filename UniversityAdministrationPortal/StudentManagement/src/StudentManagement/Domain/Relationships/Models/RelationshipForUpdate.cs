namespace StudentManagement.Domain.Relationships.Models;

using Destructurama.Attributed;

public sealed record RelationshipForUpdate
{
    public string RelationshipName { get; set; }

}
