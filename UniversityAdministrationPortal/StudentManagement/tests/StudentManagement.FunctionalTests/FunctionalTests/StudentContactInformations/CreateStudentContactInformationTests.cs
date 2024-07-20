namespace StudentManagement.FunctionalTests.FunctionalTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateStudentContactInformationTests : TestBase
{
    [Fact]
    public async Task create_studentcontactinformation_returns_created_using_valid_dto()
    {
        // Arrange
        var studentContactInformation = new FakeStudentContactInformationForCreationDto().Generate();

        // Act
        var route = ApiRoutes.StudentContactInformations.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, studentContactInformation);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}