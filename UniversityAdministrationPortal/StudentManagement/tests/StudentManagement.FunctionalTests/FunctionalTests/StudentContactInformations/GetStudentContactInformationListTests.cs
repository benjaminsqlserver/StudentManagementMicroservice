namespace StudentManagement.FunctionalTests.FunctionalTests.StudentContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetStudentContactInformationListTests : TestBase
{
    [Fact]
    public async Task get_studentcontactinformation_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.StudentContactInformations.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}