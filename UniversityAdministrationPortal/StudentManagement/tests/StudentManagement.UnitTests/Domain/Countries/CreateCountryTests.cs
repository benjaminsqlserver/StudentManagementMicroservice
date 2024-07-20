namespace StudentManagement.UnitTests.Domain.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateCountryTests
{
    private readonly Faker _faker;

    public CreateCountryTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_country()
    {
        // Arrange
        var countryToCreate = new FakeCountryForCreation().Generate();
        
        // Act
        var country = Country.Create(countryToCreate);

        // Assert
        country.CountryName.Should().Be(countryToCreate.CountryName);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var countryToCreate = new FakeCountryForCreation().Generate();
        
        // Act
        var country = Country.Create(countryToCreate);

        // Assert
        country.DomainEvents.Count.Should().Be(1);
        country.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CountryCreated));
    }
}