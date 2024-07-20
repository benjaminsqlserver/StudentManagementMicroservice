namespace StudentManagement.FunctionalTests.FunctionalTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateCountryTests : TestBase
{
    [Fact]
    public async Task create_country_returns_created_using_valid_dto()
    {
        // Arrange
        var country = new FakeCountryForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Countries.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, country);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}