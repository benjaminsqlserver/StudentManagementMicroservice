namespace StudentManagement.IntegrationTests.FeatureTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.Domain.Genders.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateGenderCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_gender_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var gender = new FakeGenderBuilder().Build();
        await testingServiceScope.InsertAsync(gender);
        var updatedGenderDto = new FakeGenderForUpdateDto().Generate();

        // Act
        var command = new UpdateGender.Command(gender.Id, updatedGenderDto);
        await testingServiceScope.SendAsync(command);
        var updatedGender = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Genders
                .FirstOrDefaultAsync(g => g.Id == gender.Id));

        // Assert
        updatedGender.GenderName.Should().Be(updatedGenderDto.GenderName);
    }
}