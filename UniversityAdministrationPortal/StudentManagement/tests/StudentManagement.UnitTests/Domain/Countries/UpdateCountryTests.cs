namespace StudentManagement.UnitTests.Domain.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateCountryTests
{
    private readonly Faker _faker;

    public UpdateCountryTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_country()
    {
        // Arrange
        var country = new FakeCountryBuilder().Build();
        var updatedCountry = new FakeCountryForUpdate().Generate();
        
        // Act
        country.Update(updatedCountry);

        // Assert
        country.CountryName.Should().Be(updatedCountry.CountryName);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var country = new FakeCountryBuilder().Build();
        var updatedCountry = new FakeCountryForUpdate().Generate();
        country.DomainEvents.Clear();
        
        // Act
        country.Update(updatedCountry);

        // Assert
        country.DomainEvents.Count.Should().Be(1);
        country.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CountryUpdated));
    }
}