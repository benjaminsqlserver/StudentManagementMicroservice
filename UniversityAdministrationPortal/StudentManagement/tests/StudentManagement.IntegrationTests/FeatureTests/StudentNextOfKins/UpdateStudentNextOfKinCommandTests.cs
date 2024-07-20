namespace StudentManagement.IntegrationTests.FeatureTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.Domain.StudentNextOfKins.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateStudentNextOfKinCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_studentnextofkin_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentNextOfKin = new FakeStudentNextOfKinBuilder().Build();
        await testingServiceScope.InsertAsync(studentNextOfKin);
        var updatedStudentNextOfKinDto = new FakeStudentNextOfKinForUpdateDto().Generate();

        // Act
        var command = new UpdateStudentNextOfKin.Command(studentNextOfKin.Id, updatedStudentNextOfKinDto);
        await testingServiceScope.SendAsync(command);
        var updatedStudentNextOfKin = await testingServiceScope
            .ExecuteDbContextAsync(db => db.StudentNextOfKins
                .FirstOrDefaultAsync(s => s.Id == studentNextOfKin.Id));

        // Assert
        updatedStudentNextOfKin.FirstName.Should().Be(updatedStudentNextOfKinDto.FirstName);
        updatedStudentNextOfKin.LastName.Should().Be(updatedStudentNextOfKinDto.LastName);
        updatedStudentNextOfKin.DateOfBirth.Should().BeCloseTo(updatedStudentNextOfKinDto.DateOfBirth, 1.Seconds());
        updatedStudentNextOfKin.GenderId.Should().Be(updatedStudentNextOfKinDto.GenderId);
        updatedStudentNextOfKin.Email.Should().Be(updatedStudentNextOfKinDto.Email);
        updatedStudentNextOfKin.PhoneNumber.Should().Be(updatedStudentNextOfKinDto.PhoneNumber);
        updatedStudentNextOfKin.StudentID.Should().Be(updatedStudentNextOfKinDto.StudentID);
        updatedStudentNextOfKin.RelationshipID.Should().Be(updatedStudentNextOfKinDto.RelationshipID);
    }
}