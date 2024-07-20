namespace StudentManagement.Domain.StudentContactInformations.DomainEvents;

public sealed class StudentContactInformationUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            