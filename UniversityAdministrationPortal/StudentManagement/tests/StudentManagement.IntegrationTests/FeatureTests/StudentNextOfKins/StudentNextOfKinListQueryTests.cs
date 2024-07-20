namespace StudentManagement.IntegrationTests.FeatureTests.StudentNextOfKins;

using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;
using StudentManagement.Domain.StudentNextOfKins.Features;
using Domain;
using System.Threading.Tasks;

public class StudentNextOfKinListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_studentnextofkin_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentNextOfKinOne = new FakeStudentNextOfKinBuilder().Build();
        var studentNextOfKinTwo = new FakeStudentNextOfKinBuilder().Build();
        var queryParameters = new StudentNextOfKinParametersDto();

        await testingServiceScope.InsertAsync(studentNextOfKinOne, studentNextOfKinTwo);

        // Act
        var query = new GetStudentNextOfKinList.Query(queryParameters);
        var studentNextOfKins = await testingServiceScope.SendAsync(query);

        // Assert
        studentNextOfKins.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}