namespace StudentManagement.FunctionalTests.FunctionalTests.NextOfKinContactInformations;

using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateNextOfKinContactInformationRecordTests : TestBase
{
    [Fact]
    public async Task put_nextofkincontactinformation_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var nextOfKinContactInformation = new FakeNextOfKinContactInformationBuilder().Build();
        var updatedNextOfKinContactInformationDto = new FakeNextOfKinContactInformationForUpdateDto().Generate();
        await InsertAsync(nextOfKinContactInformation);

        // Act
        var route = ApiRoutes.NextOfKinContactInformations.Put(nextOfKinContactInformation.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedNextOfKinContactInformationDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}