namespace StudentManagement.IntegrationTests.FeatureTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.Domain.StudentNextOfKins.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteStudentNextOfKinCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_studentnextofkin_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        await testingServiceScope.InsertAsync(studentNextOfKin);

        // Act
        var command = new DeleteStudentNextOfKin.Command(studentNextOfKin.Id);
        await testingServiceScope.SendAsync(command);
        var studentNextOfKinResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.StudentNextOfKins
                .CountAsync(s => s.Id == studentNextOfKin.Id));

        // Assert
        studentNextOfKinResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_studentnextofkin_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteStudentNextOfKin.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_studentnextofkin_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        await testingServiceScope.InsertAsync(studentNextOfKin);

        // Act
        var command = new DeleteStudentNextOfKin.Command(studentNextOfKin.Id);
        await testingServiceScope.SendAsync(command);
        var deletedStudentNextOfKin = await testingServiceScope.ExecuteDbContextAsync(db => db.StudentNextOfKins
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == studentNextOfKin.Id));

        // Assert
        deletedStudentNextOfKin?.IsDeleted.Should().BeTrue();
    }
}