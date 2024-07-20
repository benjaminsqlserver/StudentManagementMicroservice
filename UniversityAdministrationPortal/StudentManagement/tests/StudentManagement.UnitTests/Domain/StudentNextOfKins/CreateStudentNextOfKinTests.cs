namespace StudentManagement.UnitTests.Domain.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateStudentNextOfKinTests
{
    private readonly Faker _faker;

    public CreateStudentNextOfKinTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_studentNextOfKin()
    {
        // Arrange
        var studentNextOfKinToCreate = new FakeStudentNextOfKinForCreation().Generate();
        
        // Act
        var studentNextOfKin = StudentNextOfKin.Create(studentNextOfKinToCreate);

        // Assert
        studentNextOfKin.FirstName.Should().Be(studentNextOfKinToCreate.FirstName);
        studentNextOfKin.LastName.Should().Be(studentNextOfKinToCreate.LastName);
        studentNextOfKin.DateOfBirth.Should().BeCloseTo(studentNextOfKinToCreate.DateOfBirth, 1.Seconds());
        studentNextOfKin.GenderId.Should().Be(studentNextOfKinToCreate.GenderId);
        studentNextOfKin.Email.Should().Be(studentNextOfKinToCreate.Email);
        studentNextOfKin.PhoneNumber.Should().Be(studentNextOfKinToCreate.PhoneNumber);
        studentNextOfKin.StudentID.Should().Be(studentNextOfKinToCreate.StudentID);
        studentNextOfKin.RelationshipID.Should().Be(studentNextOfKinToCreate.RelationshipID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var studentNextOfKinToCreate = new FakeStudentNextOfKinForCreation().Generate();
        
        // Act
        var studentNextOfKin = StudentNextOfKin.Create(studentNextOfKinToCreate);

        // Assert
        studentNextOfKin.DomainEvents.Count.Should().Be(1);
        studentNextOfKin.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentNextOfKinCreated));
    }
}