namespace StudentManagement.IntegrationTests.FeatureTests.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.Students.Features;

public class AddStudentCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_student_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentOne = new FakeStudentForCreationDto().Generate();

        // Act
        var command = new AddStudent.Command(studentOne);
        var studentReturned = await testingServiceScope.SendAsync(command);
        var studentCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Students
            .FirstOrDefaultAsync(s => s.Id == studentReturned.Id));

        // Assert
        studentReturned.MatriculationNumber.Should().Be(studentOne.MatriculationNumber);
        studentReturned.FirstName.Should().Be(studentOne.FirstName);
        studentReturned.LastName.Should().Be(studentOne.LastName);
        studentReturned.DateOfBirth.Should().BeCloseTo(studentOne.DateOfBirth, 1.Seconds());
        studentReturned.GenderId.Should().Be(studentOne.GenderId);
        studentReturned.Email.Should().Be(studentOne.Email);
        studentReturned.PhoneNumber.Should().Be(studentOne.PhoneNumber);

        studentCreated.MatriculationNumber.Should().Be(studentOne.MatriculationNumber);
        studentCreated.FirstName.Should().Be(studentOne.FirstName);
        studentCreated.LastName.Should().Be(studentOne.LastName);
        studentCreated.DateOfBirth.Should().BeCloseTo(studentOne.DateOfBirth, 1.Seconds());
        studentCreated.GenderId.Should().Be(studentOne.GenderId);
        studentCreated.Email.Should().Be(studentOne.Email);
        studentCreated.PhoneNumber.Should().Be(studentOne.PhoneNumber);
    }
}