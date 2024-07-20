namespace StudentManagement.UnitTests.Domain.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateStudentNextOfKinTests
{
    private readonly Faker _faker;

    public UpdateStudentNextOfKinTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_studentNextOfKin()
    {
        // Arrange
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        var updatedStudentNextOfKin = new FakeStudentNextOfKinForUpdate().Generate();
        
        // Act
        studentNextOfKin.Update(updatedStudentNextOfKin);

        // Assert
        studentNextOfKin.FirstName.Should().Be(updatedStudentNextOfKin.FirstName);
        studentNextOfKin.LastName.Should().Be(updatedStudentNextOfKin.LastName);
        studentNextOfKin.DateOfBirth.Should().BeCloseTo(updatedStudentNextOfKin.DateOfBirth, 1.Seconds());
        studentNextOfKin.GenderId.Should().Be(updatedStudentNextOfKin.GenderId);
        studentNextOfKin.Email.Should().Be(updatedStudentNextOfKin.Email);
        studentNextOfKin.PhoneNumber.Should().Be(updatedStudentNextOfKin.PhoneNumber);
        studentNextOfKin.StudentID.Should().Be(updatedStudentNextOfKin.StudentID);
        studentNextOfKin.RelationshipID.Should().Be(updatedStudentNextOfKin.RelationshipID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        var updatedStudentNextOfKin = new FakeStudentNextOfKinForUpdate().Generate();
        studentNextOfKin.DomainEvents.Clear();
        
        // Act
        studentNextOfKin.Update(updatedStudentNextOfKin);

        // Assert
        studentNextOfKin.DomainEvents.Count.Should().Be(1);
        studentNextOfKin.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentNextOfKinUpdated));
    }
}