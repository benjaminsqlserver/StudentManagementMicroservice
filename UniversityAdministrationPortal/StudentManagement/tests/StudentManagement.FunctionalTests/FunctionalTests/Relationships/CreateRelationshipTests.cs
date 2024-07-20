namespace StudentManagement.FunctionalTests.FunctionalTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateRelationshipTests : TestBase
{
    [Fact]
    public async Task create_relationship_returns_created_using_valid_dto()
    {
        // Arrange
        var relationship = new FakeRelationshipForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Relationships.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, relationship);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}