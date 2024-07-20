namespace StudentManagement.IntegrationTests.FeatureTests.Students;

using StudentManagement.Domain.Students.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.Domain.Students.Features;
using Domain;
using System.Threading.Tasks;

public class StudentListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_student_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentOne = new FakeStudentBuilder().Build();
        var studentTwo = new FakeStudentBuilder().Build();
        var queryParameters = new StudentParametersDto();

        await testingServiceScope.InsertAsync(studentOne, studentTwo);

        // Act
        var query = new GetStudentList.Query(queryParameters);
        var students = await testingServiceScope.SendAsync(query);

        // Assert
        students.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}