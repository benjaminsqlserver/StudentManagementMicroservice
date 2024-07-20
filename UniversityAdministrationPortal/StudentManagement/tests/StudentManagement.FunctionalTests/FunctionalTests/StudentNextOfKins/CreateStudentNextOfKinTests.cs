namespace StudentManagement.FunctionalTests.FunctionalTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateStudentNextOfKinTests : TestBase
{
    [Fact]
    public async Task create_studentnextofkin_returns_created_using_valid_dto()
    {
        // Arrange
        var studentNextOfKin = new FakeStudentNextOfKinForCreationDto().Generate();

        // Act
        var route = ApiRoutes.StudentNextOfKins.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, studentNextOfKin);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}