namespace StudentManagement.FunctionalTests.FunctionalTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetNextOfKinContactInformationTests : TestBase
{
    [Fact]
    public async Task get_nextofkincontactinformation_returns_success_when_entity_exists()
    {
        // Arrange
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        await InsertAsync(nextOfKinContactInformation);

        // Act
        var route = ApiRoutes.NextOfKinContactInformations.GetRecord(nextOfKinContactInformation.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}