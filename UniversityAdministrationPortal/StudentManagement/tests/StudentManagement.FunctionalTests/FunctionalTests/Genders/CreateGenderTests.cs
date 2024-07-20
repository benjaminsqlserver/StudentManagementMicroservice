namespace StudentManagement.FunctionalTests.FunctionalTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateGenderTests : TestBase
{
    [Fact]
    public async Task create_gender_returns_created_using_valid_dto()
    {
        // Arrange
        var gender = new FakeGenderForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Genders.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, gender);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}