namespace StudentManagement.Domain.Relationships.DomainEvents;

public sealed class RelationshipCreated : DomainEvent
{
    public Relationship Relationship { get; set; } 
}
            