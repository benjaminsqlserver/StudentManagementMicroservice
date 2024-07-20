namespace StudentManagement.IntegrationTests.FeatureTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.Domain.Countries.Dtos;
using StudentManagement.Domain.Countries.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateCountryCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_country_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var country = new FakeCountryBuilder().Build();
        await testingServiceScope.InsertAsync(country);
        var updatedCountryDto = new FakeCountryForUpdateDto().Generate();

        // Act
        var command = new UpdateCountry.Command(country.Id, updatedCountryDto);
        await testingServiceScope.SendAsync(command);
        var updatedCountry = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Countries
                .FirstOrDefaultAsync(c => c.Id == country.Id));

        // Assert
        updatedCountry.CountryName.Should().Be(updatedCountryDto.CountryName);
    }
}