namespace StudentManagement.IntegrationTests.FeatureTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.StudentNextOfKins.Features;

public class AddStudentNextOfKinCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_studentnextofkin_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentNextOfKinOne = new FakeStudentNextOfKinForCreationDto().Generate();

        // Act
        var command = new AddStudentNextOfKin.Command(studentNextOfKinOne);
        var studentNextOfKinReturned = await testingServiceScope.SendAsync(command);
        var studentNextOfKinCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.StudentNextOfKins
            .FirstOrDefaultAsync(s => s.Id == studentNextOfKinReturned.Id));

        // Assert
        studentNextOfKinReturned.FirstName.Should().Be(studentNextOfKinOne.FirstName);
        studentNextOfKinReturned.LastName.Should().Be(studentNextOfKinOne.LastName);
        studentNextOfKinReturned.DateOfBirth.Should().BeCloseTo(studentNextOfKinOne.DateOfBirth, 1.Seconds());
        studentNextOfKinReturned.GenderId.Should().Be(studentNextOfKinOne.GenderId);
        studentNextOfKinReturned.Email.Should().Be(studentNextOfKinOne.Email);
        studentNextOfKinReturned.PhoneNumber.Should().Be(studentNextOfKinOne.PhoneNumber);
        studentNextOfKinReturned.StudentID.Should().Be(studentNextOfKinOne.StudentID);
        studentNextOfKinReturned.RelationshipID.Should().Be(studentNextOfKinOne.RelationshipID);

        studentNextOfKinCreated.FirstName.Should().Be(studentNextOfKinOne.FirstName);
        studentNextOfKinCreated.LastName.Should().Be(studentNextOfKinOne.LastName);
        studentNextOfKinCreated.DateOfBirth.Should().BeCloseTo(studentNextOfKinOne.DateOfBirth, 1.Seconds());
        studentNextOfKinCreated.GenderId.Should().Be(studentNextOfKinOne.GenderId);
        studentNextOfKinCreated.Email.Should().Be(studentNextOfKinOne.Email);
        studentNextOfKinCreated.PhoneNumber.Should().Be(studentNextOfKinOne.PhoneNumber);
        studentNextOfKinCreated.StudentID.Should().Be(studentNextOfKinOne.StudentID);
        studentNextOfKinCreated.RelationshipID.Should().Be(studentNextOfKinOne.RelationshipID);
    }
}