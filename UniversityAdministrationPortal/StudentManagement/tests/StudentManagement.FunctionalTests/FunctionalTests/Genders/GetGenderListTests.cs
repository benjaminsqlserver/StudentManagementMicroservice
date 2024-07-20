namespace StudentManagement.FunctionalTests.FunctionalTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetGenderListTests : TestBase
{
    [Fact]
    public async Task get_gender_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Genders.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}