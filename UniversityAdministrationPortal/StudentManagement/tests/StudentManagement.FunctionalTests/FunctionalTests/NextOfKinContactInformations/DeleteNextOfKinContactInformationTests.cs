namespace StudentManagement.FunctionalTests.FunctionalTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteNextOfKinContactInformationTests : TestBase
{
    [Fact]
    public async Task delete_nextofkincontactinformation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        await InsertAsync(nextOfKinContactInformation);

        // Act
        var route = ApiRoutes.NextOfKinContactInformations.Delete(nextOfKinContactInformation.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}