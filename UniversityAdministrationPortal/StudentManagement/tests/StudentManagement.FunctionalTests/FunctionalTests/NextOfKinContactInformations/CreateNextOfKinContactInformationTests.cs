namespace StudentManagement.FunctionalTests.FunctionalTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateNextOfKinContactInformationTests : TestBase
{
    [Fact]
    public async Task create_nextofkincontactinformation_returns_created_using_valid_dto()
    {
        // Arrange
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationForCreationDto().Generate();

        // Act
        var route = ApiRoutes.NextOfKinContactInformations.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, nextOfKinContactInformation);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}