namespace StudentManagement.Domain.Genders.DomainEvents;

public sealed class GenderCreated : DomainEvent
{
    public Gender Gender { get; set; } 
}
            