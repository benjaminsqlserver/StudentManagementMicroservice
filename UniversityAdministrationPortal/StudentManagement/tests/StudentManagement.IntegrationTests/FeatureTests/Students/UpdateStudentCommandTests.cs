namespace StudentManagement.IntegrationTests.FeatureTests.Students;

using StudentManagement.SharedTestHelpers.Fakes.Student;
using StudentManagement.Domain.Students.Dtos;
using StudentManagement.Domain.Students.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateStudentCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_student_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var student = new FakeStudentBuilder().Build();
        await testingServiceScope.InsertAsync(student);
        var updatedStudentDto = new FakeStudentForUpdateDto().Generate();

        // Act
        var command = new UpdateStudent.Command(student.Id, updatedStudentDto);
        await testingServiceScope.SendAsync(command);
        var updatedStudent = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Students
                .FirstOrDefaultAsync(s => s.Id == student.Id));

        // Assert
        updatedStudent.MatriculationNumber.Should().Be(updatedStudentDto.MatriculationNumber);
        updatedStudent.FirstName.Should().Be(updatedStudentDto.FirstName);
        updatedStudent.LastName.Should().Be(updatedStudentDto.LastName);
        updatedStudent.DateOfBirth.Should().BeCloseTo(updatedStudentDto.DateOfBirth, 1.Seconds());
        updatedStudent.GenderId.Should().Be(updatedStudentDto.GenderId);
        updatedStudent.Email.Should().Be(updatedStudentDto.Email);
        updatedStudent.PhoneNumber.Should().Be(updatedStudentDto.PhoneNumber);
    }
}