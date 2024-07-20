namespace StudentManagement.FunctionalTests.FunctionalTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetRelationshipTests : TestBase
{
    [Fact]
    public async Task get_relationship_returns_success_when_entity_exists()
    {
        // Arrange
        var relationship = new FakeRelationshipBuilder().Build();
        await InsertAsync(relationship);

        // Act
        var route = ApiRoutes.Relationships.GetRecord(relationship.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}