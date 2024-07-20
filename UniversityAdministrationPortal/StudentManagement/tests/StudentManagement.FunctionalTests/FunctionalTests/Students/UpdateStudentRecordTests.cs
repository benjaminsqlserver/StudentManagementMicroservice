namespace StudentManagement.FunctionalTests.FunctionalTests.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateStudentRecordTests : TestBase
{
    [Fact]
    public async Task put_student_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var student = new FakeStudentBuilder().Build();
        var updatedStudentDto = new FakeStudentForUpdateDto().Generate();
        await InsertAsync(student);

        // Act
        var route = ApiRoutes.Students.Put(student.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedStudentDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}