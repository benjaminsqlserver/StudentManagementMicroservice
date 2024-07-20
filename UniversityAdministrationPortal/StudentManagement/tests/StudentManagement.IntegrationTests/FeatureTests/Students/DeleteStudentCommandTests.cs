namespace StudentManagement.IntegrationTests.FeatureTests.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.Domain.Students.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteStudentCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_student_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var student = new FakeStudentBuilder().Build();
        await testingServiceScope.InsertAsync(student);

        // Act
        var command = new DeleteStudent.Command(student.Id);
        await testingServiceScope.SendAsync(command);
        var studentResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Students
                .CountAsync(s => s.Id == student.Id));

        // Assert
        studentResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_student_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteStudent.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_student_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var student = new FakeStudentBuilder().Build();
        await testingServiceScope.InsertAsync(student);

        // Act
        var command = new DeleteStudent.Command(student.Id);
        await testingServiceScope.SendAsync(command);
        var deletedStudent = await testingServiceScope.ExecuteDbContextAsync(db => db.Students
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == student.Id));

        // Assert
        deletedStudent?.IsDeleted.Should().BeTrue();
    }
}