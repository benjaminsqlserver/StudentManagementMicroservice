namespace StudentManagement.FunctionalTests.FunctionalTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetNextOfKinContactInformationListTests : TestBase
{
    [Fact]
    public async Task get_nextofkincontactinformation_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.NextOfKinContactInformations.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}