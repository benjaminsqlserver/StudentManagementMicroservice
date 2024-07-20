namespace StudentManagement.IntegrationTests.FeatureTests.Countries;

using StudentManagement.Domain.Countries.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.Domain.Countries.Features;
using Domain;
using System.Threading.Tasks;

public class CountryListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_country_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var countryOne = new FakeCountryBuilder().Build();
        var countryTwo = new FakeCountryBuilder().Build();
        var queryParameters = new CountryParametersDto();

        await testingServiceScope.InsertAsync(countryOne, countryTwo);

        // Act
        var query = new GetCountryList.Query(queryParameters);
        var countries = await testingServiceScope.SendAsync(query);

        // Assert
        countries.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}