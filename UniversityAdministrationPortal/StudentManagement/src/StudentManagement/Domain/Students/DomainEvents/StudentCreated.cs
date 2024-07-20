namespace StudentManagement.Domain.Students.DomainEvents;

public sealed class StudentCreated : DomainEvent
{
    public Student Student { get; set; } 
}
            