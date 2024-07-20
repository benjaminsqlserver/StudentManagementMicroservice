namespace StudentManagement.UnitTests.Domain.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateNextOfKinContactInformationTests
{
    private readonly Faker _faker;

    public CreateNextOfKinContactInformationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_nextOfKinContactInformation()
    {
        // Arrange
        var nextOfKinContactInformationToCreate = new FakeNextOfKinContactInformationForCreation().Generate();
        
        // Act
        var nextOfKinContactInformation = NextOfKinContactInformation.Create(nextOfKinContactInformationToCreate);

        // Assert
        nextOfKinContactInformation.HouseAddress.Should().Be(nextOfKinContactInformationToCreate.HouseAddress);
        nextOfKinContactInformation.City.Should().Be(nextOfKinContactInformationToCreate.City);
        nextOfKinContactInformation.State.Should().Be(nextOfKinContactInformationToCreate.State);
        nextOfKinContactInformation.ZipCode.Should().Be(nextOfKinContactInformationToCreate.ZipCode);
        nextOfKinContactInformation.CountryID.Should().Be(nextOfKinContactInformationToCreate.CountryID);
        nextOfKinContactInformation.NextOfKinID.Should().Be(nextOfKinContactInformationToCreate.NextOfKinID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var nextOfKinContactInformationToCreate = new FakeNextOfKinContactInformationForCreation().Generate();
        
        // Act
        var nextOfKinContactInformation = NextOfKinContactInformation.Create(nextOfKinContactInformationToCreate);

        // Assert
        nextOfKinContactInformation.DomainEvents.Count.Should().Be(1);
        nextOfKinContactInformation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(NextOfKinContactInformationCreated));
    }
}