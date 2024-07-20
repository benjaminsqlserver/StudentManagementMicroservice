namespace StudentManagement.Domain.Students.DomainEvents;

public sealed class StudentUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            