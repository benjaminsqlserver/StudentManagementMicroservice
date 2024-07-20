namespace StudentManagement.IntegrationTests.FeatureTests.StudentNextOfKins;

using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.Domain.StudentNextOfKins.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class StudentNextOfKinQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_studentnextofkin_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentNextOfKinOne = new FakeStudentNextOfKinBuilder().Build();
        await testingServiceScope.InsertAsync(studentNextOfKinOne);

        // Act
        var query = new GetStudentNextOfKin.Query(studentNextOfKinOne.Id);
        var studentNextOfKin = await testingServiceScope.SendAsync(query);

        // Assert
        studentNextOfKin.FirstName.Should().Be(studentNextOfKinOne.FirstName);
        studentNextOfKin.LastName.Should().Be(studentNextOfKinOne.LastName);
        studentNextOfKin.DateOfBirth.Should().BeCloseTo(studentNextOfKinOne.DateOfBirth, 1.Seconds());
        studentNextOfKin.GenderId.Should().Be(studentNextOfKinOne.GenderId);
        studentNextOfKin.Email.Should().Be(studentNextOfKinOne.Email);
        studentNextOfKin.PhoneNumber.Should().Be(studentNextOfKinOne.PhoneNumber);
        studentNextOfKin.StudentID.Should().Be(studentNextOfKinOne.StudentID);
        studentNextOfKin.RelationshipID.Should().Be(studentNextOfKinOne.RelationshipID);
    }

    [Fact]
    public async Task get_studentnextofkin_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetStudentNextOfKin.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}