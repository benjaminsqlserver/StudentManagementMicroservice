namespace StudentManagement.UnitTests.Domain.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateGenderTests
{
    private readonly Faker _faker;

    public UpdateGenderTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_gender()
    {
        // Arrange
        var gender = new FakeGenderBuilder().Build();
        var updatedGender = new FakeGenderForUpdate().Generate();
        
        // Act
        gender.Update(updatedGender);

        // Assert
        gender.GenderName.Should().Be(updatedGender.GenderName);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var gender = new FakeGenderBuilder().Build();
        var updatedGender = new FakeGenderForUpdate().Generate();
        gender.DomainEvents.Clear();
        
        // Act
        gender.Update(updatedGender);

        // Assert
        gender.DomainEvents.Count.Should().Be(1);
        gender.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(GenderUpdated));
    }
}