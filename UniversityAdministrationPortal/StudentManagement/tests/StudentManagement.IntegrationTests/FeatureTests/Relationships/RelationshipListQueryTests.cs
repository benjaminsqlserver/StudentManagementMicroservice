namespace StudentManagement.IntegrationTests.FeatureTests.Relationships;

using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.Domain.Relationships.Features;
using Domain;
using System.Threading.Tasks;

public class RelationshipListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_relationship_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var relationshipOne = new FakeRelationshipBuilder().Build();
        var relationshipTwo = new FakeRelationshipBuilder().Build();
        var queryParameters = new RelationshipParametersDto();

        await testingServiceScope.InsertAsync(relationshipOne, relationshipTwo);

        // Act
        var query = new GetRelationshipList.Query(queryParameters);
        var relationships = await testingServiceScope.SendAsync(query);

        // Assert
        relationships.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}