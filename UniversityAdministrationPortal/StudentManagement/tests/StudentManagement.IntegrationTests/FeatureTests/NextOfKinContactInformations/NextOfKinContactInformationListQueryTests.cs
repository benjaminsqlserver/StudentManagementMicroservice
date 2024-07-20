namespace StudentManagement.IntegrationTests.FeatureTests.NextOfKinContactInformations;

using StudentManagement.Domain.NextOfKinContactInformations.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;
using StudentManagement.Domain.NextOfKinContactInformations.Features;
using Domain;
using System.Threading.Tasks;

public class NextOfKinContactInformationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_nextofkincontactinformation_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var nextOfKinContactInformationOne = new FakeNextOfKinContactInformationBuilder().Build();
        var nextOfKinContactInformationTwo = new FakeNextOfKinContactInformationBuilder().Build();
        var queryParameters = new NextOfKinContactInformationParametersDto();

        await testingServiceScope.InsertAsync(nextOfKinContactInformationOne, nextOfKinContactInformationTwo);

        // Act
        var query = new GetNextOfKinContactInformationList.Query(queryParameters);
        var nextOfKinContactInformations = await testingServiceScope.SendAsync(query);

        // Assert
        nextOfKinContactInformations.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}