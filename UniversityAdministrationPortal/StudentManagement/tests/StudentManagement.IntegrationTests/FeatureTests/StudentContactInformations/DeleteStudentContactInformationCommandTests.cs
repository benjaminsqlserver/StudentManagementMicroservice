namespace StudentManagement.IntegrationTests.FeatureTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.Domain.StudentContactInformations.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteStudentContactInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_studentcontactinformation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(studentContactInformation);

        // Act
        var command = new DeleteStudentContactInformation.Command(studentContactInformation.Id);
        await testingServiceScope.SendAsync(command);
        var studentContactInformationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.StudentContactInformations
                .CountAsync(s => s.Id == studentContactInformation.Id));

        // Assert
        studentContactInformationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_studentcontactinformation_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteStudentContactInformation.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_studentcontactinformation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(studentContactInformation);

        // Act
        var command = new DeleteStudentContactInformation.Command(studentContactInformation.Id);
        await testingServiceScope.SendAsync(command);
        var deletedStudentContactInformation = await testingServiceScope.ExecuteDbContextAsync(db => db.StudentContactInformations
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == studentContactInformation.Id));

        // Assert
        deletedStudentContactInformation?.IsDeleted.Should().BeTrue();
    }
}