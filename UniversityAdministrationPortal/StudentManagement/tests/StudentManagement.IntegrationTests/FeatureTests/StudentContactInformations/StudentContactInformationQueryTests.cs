namespace StudentManagement.IntegrationTests.FeatureTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.Domain.StudentContactInformations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class StudentContactInformationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_studentcontactinformation_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentContactInformationOne = new FakeStudentContactInformationBuilder().Build();
        await testingServiceScope.InsertAsync(studentContactInformationOne);

        // Act
        var query = new GetStudentContactInformation.Query(studentContactInformationOne.Id);
        var studentContactInformation = await testingServiceScope.SendAsync(query);

        // Assert
        studentContactInformation.HouseAddress.Should().Be(studentContactInformationOne.HouseAddress);
        studentContactInformation.City.Should().Be(studentContactInformationOne.City);
        studentContactInformation.State.Should().Be(studentContactInformationOne.State);
        studentContactInformation.ZipCode.Should().Be(studentContactInformationOne.ZipCode);
        studentContactInformation.CountryID.Should().Be(studentContactInformationOne.CountryID);
        studentContactInformation.StudentID.Should().Be(studentContactInformationOne.StudentID);
    }

    [Fact]
    public async Task get_studentcontactinformation_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetStudentContactInformation.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}