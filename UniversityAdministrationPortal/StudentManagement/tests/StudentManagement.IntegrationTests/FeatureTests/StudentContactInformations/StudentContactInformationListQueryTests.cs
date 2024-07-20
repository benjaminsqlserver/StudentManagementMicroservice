namespace StudentManagement.IntegrationTests.FeatureTests.StudentContactInformations;

using StudentManagement.Domain.StudentContactInformations.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.Domain.StudentContactInformations.Features;
using Domain;
using System.Threading.Tasks;

public class StudentContactInformationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_studentcontactinformation_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var studentContactInformationOne = new FakeStudentContactInformationBuilder().Build();
        var studentContactInformationTwo = new FakeStudentContactInformationBuilder().Build();
        var queryParameters = new StudentContactInformationParametersDto();

        await testingServiceScope.InsertAsync(studentContactInformationOne, studentContactInformationTwo);

        // Act
        var query = new GetStudentContactInformationList.Query(queryParameters);
        var studentContactInformations = await testingServiceScope.SendAsync(query);

        // Assert
        studentContactInformations.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}