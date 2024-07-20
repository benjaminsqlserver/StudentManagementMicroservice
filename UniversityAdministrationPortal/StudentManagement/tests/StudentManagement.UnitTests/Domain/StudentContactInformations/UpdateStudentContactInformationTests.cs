namespace StudentManagement.UnitTests.Domain.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateStudentContactInformationTests
{
    private readonly Faker _faker;

    public UpdateStudentContactInformationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_studentContactInformation()
    {
        // Arrange
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        var updatedStudentContactInformation = new FakeStudentContactInformationForUpdate().Generate();
        
        // Act
        studentContactInformation.Update(updatedStudentContactInformation);

        // Assert
        studentContactInformation.HouseAddress.Should().Be(updatedStudentContactInformation.HouseAddress);
        studentContactInformation.City.Should().Be(updatedStudentContactInformation.City);
        studentContactInformation.State.Should().Be(updatedStudentContactInformation.State);
        studentContactInformation.ZipCode.Should().Be(updatedStudentContactInformation.ZipCode);
        studentContactInformation.CountryID.Should().Be(updatedStudentContactInformation.CountryID);
        studentContactInformation.StudentID.Should().Be(updatedStudentContactInformation.StudentID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        var updatedStudentContactInformation = new FakeStudentContactInformationForUpdate().Generate();
        studentContactInformation.DomainEvents.Clear();
        
        // Act
        studentContactInformation.Update(updatedStudentContactInformation);

        // Assert
        studentContactInformation.DomainEvents.Count.Should().Be(1);
        studentContactInformation.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StudentContactInformationUpdated));
    }
}