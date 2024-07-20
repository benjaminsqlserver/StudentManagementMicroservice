namespace StudentManagement.Domain.Countries.DomainEvents;

public sealed class CountryUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            