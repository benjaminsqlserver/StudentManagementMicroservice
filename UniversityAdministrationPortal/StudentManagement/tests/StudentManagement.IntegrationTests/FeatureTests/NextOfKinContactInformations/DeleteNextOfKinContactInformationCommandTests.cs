namespace StudentManagement.IntegrationTests.FeatureTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.Domain.NextOfKinContactInformations.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteNextOfKinContactInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_nextofkincontactinformation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(nextOfKinContactInformation);

        // Act
        var command = new DeleteNextOfKinContactInformation.Command(nextOfKinContactInformation.Id);
        await testingServiceScope.SendAsync(command);
        var nextOfKinContactInformationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.NextOfKinContactInformations
                .CountAsync(n => n.Id == nextOfKinContactInformation.Id));

        // Assert
        nextOfKinContactInformationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_nextofkincontactinformation_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteNextOfKinContactInformation.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_nextofkincontactinformation_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(nextOfKinContactInformation);

        // Act
        var command = new DeleteNextOfKinContactInformation.Command(nextOfKinContactInformation.Id);
        await testingServiceScope.SendAsync(command);
        var deletedNextOfKinContactInformation = await testingServiceScope.ExecuteDbContextAsync(db => db.NextOfKinContactInformations
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == nextOfKinContactInformation.Id));

        // Assert
        deletedNextOfKinContactInformation?.IsDeleted.Should().BeTrue();
    }
}