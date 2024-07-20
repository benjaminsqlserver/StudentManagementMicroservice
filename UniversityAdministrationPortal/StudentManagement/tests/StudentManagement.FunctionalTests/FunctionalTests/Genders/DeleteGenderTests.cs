namespace StudentManagement.FunctionalTests.FunctionalTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteGenderTests : TestBase
{
    [Fact]
    public async Task delete_gender_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var gender = new FakeGenderBuilder().Build();
        await InsertAsync(gender);

        // Act
        var route = ApiRoutes.Genders.Delete(gender.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}