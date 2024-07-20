namespace StudentManagement.Domain.StudentNextOfKins.DomainEvents;

public sealed class StudentNextOfKinUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            