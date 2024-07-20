namespace StudentManagement.Domain.StudentNextOfKins.DomainEvents;

public sealed class StudentNextOfKinCreated : DomainEvent
{
    public StudentNextOfKin StudentNextOfKin { get; set; } 
}
            