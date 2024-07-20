namespace StudentManagement.IntegrationTests.FeatureTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.Countries.Features;

public class AddCountryCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_country_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var countryOne = new FakeCountryForCreationDto().Generate();

        // Act
        var command = new AddCountry.Command(countryOne);
        var countryReturned = await testingServiceScope.SendAsync(command);
        var countryCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Countries
            .FirstOrDefaultAsync(c => c.Id == countryReturned.Id));

        // Assert
        countryReturned.CountryName.Should().Be(countryOne.CountryName);

        countryCreated.CountryName.Should().Be(countryOne.CountryName);
    }
}