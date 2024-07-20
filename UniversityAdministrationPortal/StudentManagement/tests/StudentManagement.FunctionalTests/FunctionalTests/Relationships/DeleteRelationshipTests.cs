namespace StudentManagement.FunctionalTests.FunctionalTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteRelationshipTests : TestBase
{
    [Fact]
    public async Task delete_relationship_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var relationship = new FakeRelationshipBuilder().Build();
        await InsertAsync(relationship);

        // Act
        var route = ApiRoutes.Relationships.Delete(relationship.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}