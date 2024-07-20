namespace StudentManagement.FunctionalTests.FunctionalTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetStudentContactInformationTests : TestBase
{
    [Fact]
    public async Task get_studentcontactinformation_returns_success_when_entity_exists()
    {
        // Arrange
        var studentContactInformation = new FakeStudentContactInformationBuilder().Build();
        await InsertAsync(studentContactInformation);

        // Act
        var route = ApiRoutes.StudentContactInformations.GetRecord(studentContactInformation.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}