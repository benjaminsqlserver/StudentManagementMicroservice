namespace StudentManagement.UnitTests.Domain.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateNextOfKinContactInformationTests
{
    private readonly Faker _faker;

    public UpdateNextOfKinContactInformationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_nextOfKinContactInformation()
    {
        // Arrange
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        var updatedNextOfKinContactInformation = new FakeNextOfKinContactInformationForUpdate().Generate();
        
        // Act
        nextOfKinContactInformation.Update(updatedNextOfKinContactInformation);

        // Assert
        nextOfKinContactInformation.HouseAddress.Should().Be(updatedNextOfKinContactInformation.HouseAddress);
        nextOfKinContactInformation.City.Should().Be(updatedNextOfKinContactInformation.City);
        nextOfKinContactInformation.State.Should().Be(updatedNextOfKinContactInformation.State);
        nextOfKinContactInformation.ZipCode.Should().Be(updatedNextOfKinContactInformation.ZipCode);
        nextOfKinContactInformation.CountryID.Should().Be(updatedNextOfKinContactInformation.CountryID);
        nextOfKinContactInformation.NextOfKinID.Should().Be(updatedNextOfKinContactInformation.NextOfKinID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        var updatedNextOfKinContactInformation = new FakeNextOfKinContactInformationForUpdate().Generate();
        nextOfKinContactInformation.DomainEvents.Clear();
        
        // Act
        nextOfKinContactInformation.Update(updatedNextOfKinContactInformation);

        // Assert
        nextOfKinContactInformation.DomainEvents.Count.Should().Be(1);
        nextOfKinContactInformation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(NextOfKinContactInformationUpdated));
    }
}