namespace StudentManagement.FunctionalTests.FunctionalTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetCountryTests : TestBase
{
    [Fact]
    public async Task get_country_returns_success_when_entity_exists()
    {
        // Arrange
        var country = new FakeCountryBuilder().Build();
        await InsertAsync(country);

        // Act
        var route = ApiRoutes.Countries.GetRecord(country.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}