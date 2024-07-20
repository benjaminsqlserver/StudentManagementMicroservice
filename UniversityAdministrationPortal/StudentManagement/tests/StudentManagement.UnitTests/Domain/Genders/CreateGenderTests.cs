namespace StudentManagement.UnitTests.Domain.Genders;

using StudentManagement.SharedTestHelpers.Fakes.Gender;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateGenderTests
{
    private readonly Faker _faker;

    public CreateGenderTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_gender()
    {
        // Arrange
        var genderToCreate = new FakeGenderForCreation().Generate();
        
        // Act
        var gender = Gender.Create(genderToCreate);

        // Assert
        gender.GenderName.Should().Be(genderToCreate.GenderName);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var genderToCreate = new FakeGenderForCreation().Generate();
        
        // Act
        var gender = Gender.Create(genderToCreate);

        // Assert
        gender.DomainEvents.Count.Should().Be(1);
        gender.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(GenderCreated));
    }
}