namespace StudentManagement.FunctionalTests.FunctionalTests.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetStudentListTests : TestBase
{
    [Fact]
    public async Task get_student_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Students.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}