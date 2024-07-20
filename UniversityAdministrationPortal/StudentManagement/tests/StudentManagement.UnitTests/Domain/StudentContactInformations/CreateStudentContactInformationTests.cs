namespace StudentManagement.UnitTests.Domain.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateStudentContactInformationTests
{
    private readonly Faker _faker;

    public CreateStudentContactInformationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_studentContactInformation()
    {
        // Arrange
        var studentContactInformationToCreate = new FakeStudentContactInformationForCreation().Generate();
        
        // Act
        var studentContactInformation = StudentContactInformation.Create(studentContactInformationToCreate);

        // Assert
        studentContactInformation.HouseAddress.Should().Be(studentContactInformationToCreate.HouseAddress);
        studentContactInformation.City.Should().Be(studentContactInformationToCreate.City);
        studentContactInformation.State.Should().Be(studentContactInformationToCreate.State);
        studentContactInformation.ZipCode.Should().Be(studentContactInformationToCreate.ZipCode);
        studentContactInformation.CountryID.Should().Be(studentContactInformationToCreate.CountryID);
        studentContactInformation.StudentID.Should().Be(studentContactInformationToCreate.StudentID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var studentContactInformationToCreate = new FakeStudentContactInformationForCreation().Generate();
        
        // Act
        var studentContactInformation = StudentContactInformation.Create(studentContactInformationToCreate);

        // Assert
        studentContactInformation.DomainEvents.Count.Should().Be(1);
        studentContactInformation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentContactInformationCreated));
    }
}