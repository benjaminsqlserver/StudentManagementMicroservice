namespace StudentManagement.IntegrationTests.FeatureTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.StudentContactInformations.Features;

public class AddStudentContactInformationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_studentcontactinformation_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentContactInformationOne = new FakeStudentContactInformationForCreationDto().Generate();

        // Act
        var command = new AddStudentContactInformation.Command(studentContactInformationOne);
        var studentContactInformationReturned = await testingServiceScope.SendAsync(command);
        var studentContactInformationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.StudentContactInformations
            .FirstOrDefaultAsync(s => s.Id == studentContactInformationReturned.Id));

        // Assert
        studentContactInformationReturned.HouseAddress.Should().Be(studentContactInformationOne.HouseAddress);
        studentContactInformationReturned.City.Should().Be(studentContactInformationOne.City);
        studentContactInformationReturned.State.Should().Be(studentContactInformationOne.State);
        studentContactInformationReturned.ZipCode.Should().Be(studentContactInformationOne.ZipCode);
        studentContactInformationReturned.CountryID.Should().Be(studentContactInformationOne.CountryID);
        studentContactInformationReturned.StudentID.Should().Be(studentContactInformationOne.StudentID);

        studentContactInformationCreated.HouseAddress.Should().Be(studentContactInformationOne.HouseAddress);
        studentContactInformationCreated.City.Should().Be(studentContactInformationOne.City);
        studentContactInformationCreated.State.Should().Be(studentContactInformationOne.State);
        studentContactInformationCreated.ZipCode.Should().Be(studentContactInformationOne.ZipCode);
        studentContactInformationCreated.CountryID.Should().Be(studentContactInformationOne.CountryID);
        studentContactInformationCreated.StudentID.Should().Be(studentContactInformationOne.StudentID);
    }
}