namespace StudentManagement.IntegrationTests.FeatureTests.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.Domain.Genders.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class GenderQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_gender_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var genderOne = new FakeGenderBuilder().Build();
        await testingServiceScope.InsertAsync(genderOne);

        // Act
        var query = new GetGender.Query(genderOne.Id);
        var gender = await testingServiceScope.SendAsync(query);

        // Assert
        gender.GenderName.Should().Be(genderOne.GenderName);
    }

    [Fact]
    public async Task get_gender_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetGender.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}