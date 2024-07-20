namespace StudentManagement.FunctionalTests.FunctionalTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetGenderTests : TestBase
{
    [Fact]
    public async Task get_gender_returns_success_when_entity_exists()
    {
        // Arrange
        var gender = new FakeGenderBuilder().Build();
        await InsertAsync(gender);

        // Act
        var route = ApiRoutes.Genders.GetRecord(gender.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}