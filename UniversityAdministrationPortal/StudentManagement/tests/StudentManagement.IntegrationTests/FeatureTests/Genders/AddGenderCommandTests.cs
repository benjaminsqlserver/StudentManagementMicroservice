namespace StudentManagement.IntegrationTests.FeatureTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.Genders.Features;

public class AddGenderCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_gender_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var genderOne = new FakeGenderForCreationDto().Generate();

        // Act
        var command = new AddGender.Command(genderOne);
        var genderReturned = await testingServiceScope.SendAsync(command);
        var genderCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Genders
            .FirstOrDefaultAsync(g => g.Id == genderReturned.Id));

        // Assert
        genderReturned.GenderName.Should().Be(genderOne.GenderName);

        genderCreated.GenderName.Should().Be(genderOne.GenderName);
    }
}