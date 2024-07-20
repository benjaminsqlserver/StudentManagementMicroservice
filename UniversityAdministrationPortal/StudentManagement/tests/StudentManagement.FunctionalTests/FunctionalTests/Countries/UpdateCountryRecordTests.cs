namespace StudentManagement.FunctionalTests.FunctionalTests.Countries;

using StudentManagement.SharedTestHelpers.Fakes.Country;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateCountryRecordTests : TestBase
{
    [Fact]
    public async Task put_country_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var country = new FakeCountryBuilder().Build();
        var updatedCountryDto = new FakeCountryForUpdateDto().Generate();
        await InsertAsync(country);

        // Act
        var route = ApiRoutes.Countries.Put(country.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedCountryDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}