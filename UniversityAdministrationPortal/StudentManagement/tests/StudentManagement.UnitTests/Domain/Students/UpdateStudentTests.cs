namespace StudentManagement.UnitTests.Domain.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateStudentTests
{
    private readonly Faker _faker;

    public UpdateStudentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_student()
    {
        // Arrange
        var student = new FakeStudentBuilder().Build();
        var updatedStudent = new FakeStudentForUpdate().Generate();
        
        // Act
        student.Update(updatedStudent);

        // Assert
        student.MatriculationNumber.Should().Be(updatedStudent.MatriculationNumber);
        student.FirstName.Should().Be(updatedStudent.FirstName);
        student.LastName.Should().Be(updatedStudent.LastName);
        student.DateOfBirth.Should().BeCloseTo(updatedStudent.DateOfBirth, 1.Seconds());
        student.GenderId.Should().Be(updatedStudent.GenderId);
        student.Email.Should().Be(updatedStudent.Email);
        student.PhoneNumber.Should().Be(updatedStudent.PhoneNumber);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var student = new FakeStudentBuilder().Build();
        var updatedStudent = new FakeStudentForUpdate().Generate();
        student.DomainEvents.Clear();
        
        // Act
        student.Update(updatedStudent);

        // Assert
        student.DomainEvents.Count.Should().Be(1);
        student.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentUpdated));
    }
}