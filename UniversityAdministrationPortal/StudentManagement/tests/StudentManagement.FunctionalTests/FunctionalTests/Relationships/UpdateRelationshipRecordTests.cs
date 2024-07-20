namespace StudentManagement.FunctionalTests.FunctionalTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateRelationshipRecordTests : TestBase
{
    [Fact]
    public async Task put_relationship_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var relationship = new FakeRelationshipBuilder().Build();
        var updatedRelationshipDto = new FakeRelationshipForUpdateDto().Generate();
        await InsertAsync(relationship);

        // Act
        var route = ApiRoutes.Relationships.Put(relationship.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedRelationshipDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}