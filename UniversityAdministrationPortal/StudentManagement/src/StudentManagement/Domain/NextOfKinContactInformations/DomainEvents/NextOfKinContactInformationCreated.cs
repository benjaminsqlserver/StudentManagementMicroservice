namespace StudentManagement.Domain.NextOfKinContactInformations.DomainEvents;

public sealed class NextOfKinContactInformationCreated : DomainEvent
{
    public NextOfKinContactInformation NextOfKinContactInformation { get; set; } 
}
            