namespace StudentManagement.Domain.StudentContactInformations.DomainEvents;

public sealed class StudentContactInformationCreated : DomainEvent
{
    public StudentContactInformation StudentContactInformation { get; set; } 
}
            