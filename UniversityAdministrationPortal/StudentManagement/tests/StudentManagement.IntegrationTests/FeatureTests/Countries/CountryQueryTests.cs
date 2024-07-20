namespace StudentManagement.IntegrationTests.FeatureTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.Domain.Countries.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class CountryQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_country_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var countryOne = new FakeCountryBuilder().Build();
        await testingServiceScope.InsertAsync(countryOne);

        // Act
        var query = new GetCountry.Query(countryOne.Id);
        var country = await testingServiceScope.SendAsync(query);

        // Assert
        country.CountryName.Should().Be(countryOne.CountryName);
    }

    [Fact]
    public async Task get_country_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetCountry.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}