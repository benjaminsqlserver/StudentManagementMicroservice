namespace StudentManagement.Domain.Genders.DomainEvents;

public sealed class GenderUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            