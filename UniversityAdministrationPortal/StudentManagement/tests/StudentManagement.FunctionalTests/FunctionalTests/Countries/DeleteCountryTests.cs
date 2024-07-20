namespace StudentManagement.FunctionalTests.FunctionalTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteCountryTests : TestBase
{
    [Fact]
    public async Task delete_country_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var country = new FakeCountryBuilder().Build();
        await InsertAsync(country);

        // Act
        var route = ApiRoutes.Countries.Delete(country.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}