namespace StudentManagement.IntegrationTests.FeatureTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.Domain.Genders.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteGenderCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_gender_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var gender = new FakeGenderBuilder().Build();
        await testingServiceScope.InsertAsync(gender);

        // Act
        var command = new DeleteGender.Command(gender.Id);
        await testingServiceScope.SendAsync(command);
        var genderResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Genders
                .CountAsync(g => g.Id == gender.Id));

        // Assert
        genderResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_gender_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteGender.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_gender_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var gender = new FakeGenderBuilder().Build();
        await testingServiceScope.InsertAsync(gender);

        // Act
        var command = new DeleteGender.Command(gender.Id);
        await testingServiceScope.SendAsync(command);
        var deletedGender = await testingServiceScope.ExecuteDbContextAsync(db => db.Genders
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == gender.Id));

        // Assert
        deletedGender?.IsDeleted.Should().BeTrue();
    }
}