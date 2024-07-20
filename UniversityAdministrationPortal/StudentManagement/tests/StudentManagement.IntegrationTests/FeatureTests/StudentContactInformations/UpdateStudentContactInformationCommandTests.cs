namespace StudentManagement.IntegrationTests.FeatureTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.Domain.StudentContactInformations.Dtos;
using StudentManagement.Domain.StudentContactInformations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateStudentContactInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_studentcontactinformation_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(studentContactInformation);
        var updatedStudentContactInformationDto = new FakeStudentContactInformationForUpdateDto().Generate();

        // Act
        var command = new UpdateStudentContactInformation.Command(studentContactInformation.Id, updatedStudentContactInformationDto);
        await testingServiceScope.SendAsync(command);
        var updatedStudentContactInformation = await testingServiceScope
            .ExecuteDbContextAsync(db => db.StudentContactInformations
                .FirstOrDefaultAsync(s => s.Id == studentContactInformation.Id));

        // Assert
        updatedStudentContactInformation.HouseAddress.Should().Be(updatedStudentContactInformationDto.HouseAddress);
        updatedStudentContactInformation.City.Should().Be(updatedStudentContactInformationDto.City);
        updatedStudentContactInformation.State.Should().Be(updatedStudentContactInformationDto.State);
        updatedStudentContactInformation.ZipCode.Should().Be(updatedStudentContactInformationDto.ZipCode);
        updatedStudentContactInformation.CountryID.Should().Be(updatedStudentContactInformationDto.CountryID);
        updatedStudentContactInformation.StudentID.Should().Be(updatedStudentContactInformationDto.StudentID);
    }
}