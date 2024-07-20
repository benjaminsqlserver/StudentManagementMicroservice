namespace StudentManagement.FunctionalTests.FunctionalTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetRelationshipListTests : TestBase
{
    [Fact]
    public async Task get_relationship_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Relationships.GetList());

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}