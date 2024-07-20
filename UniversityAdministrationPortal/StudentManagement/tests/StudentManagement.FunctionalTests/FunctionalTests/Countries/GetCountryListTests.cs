namespace StudentManagement.FunctionalTests.FunctionalTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetCountryListTests : TestBase
{
    [Fact]
    public async Task get_country_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Countries.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}