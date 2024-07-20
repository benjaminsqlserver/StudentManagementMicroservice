namespace StudentManagement.UnitTests.Domain.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateStudentTests
{
    private readonly Faker _faker;

    public CreateStudentTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_student()
    {
        // Arrange
        var studentToCreate = new FakeStudentForCreation().Generate();
        
        // Act
        var student = Student.Create(studentToCreate);

        // Assert
        student.MatriculationNumber.Should().Be(studentToCreate.MatriculationNumber);
        student.FirstName.Should().Be(studentToCreate.FirstName);
        student.LastName.Should().Be(studentToCreate.LastName);
        student.DateOfBirth.Should().BeCloseTo(studentToCreate.DateOfBirth, 1.Seconds());
        student.GenderId.Should().Be(studentToCreate.GenderId);
        student.Email.Should().Be(studentToCreate.Email);
        student.PhoneNumber.Should().Be(studentToCreate.PhoneNumber);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var studentToCreate = new FakeStudentForCreation().Generate();
        
        // Act
        var student = Student.Create(studentToCreate);

        // Assert
        student.DomainEvents.Count.Should().Be(1);
        student.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentCreated));
    }
}