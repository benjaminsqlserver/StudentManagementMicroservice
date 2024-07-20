namespace StudentManagement.FunctionalTests.FunctionalTests.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateStudentTests : TestBase
{
    [Fact]
    public async Task create_student_returns_created_using_valid_dto()
    {
        // Arrange
        var student = new FakeStudentForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Students.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, student);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}