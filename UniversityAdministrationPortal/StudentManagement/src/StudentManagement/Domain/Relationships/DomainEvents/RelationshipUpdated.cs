namespace StudentManagement.Domain.Relationships.DomainEvents;

public sealed class RelationshipUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            