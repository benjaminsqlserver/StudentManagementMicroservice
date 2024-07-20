namespace StudentManagement.IntegrationTests.FeatureTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentManagement.Domain.Relationships.Features;

public class AddRelationshipCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_relationship_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var relationshipOne = new FakeRelationshipForCreationDto().Generate();

        // Act
        var command = new AddRelationship.Command(relationshipOne);
        var relationshipReturned = await testingServiceScope.SendAsync(command);
        var relationshipCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Relationships
            .FirstOrDefaultAsync(r => r.Id == relationshipReturned.Id));

        // Assert
        relationshipReturned.RelationshipName.Should().Be(relationshipOne.RelationshipName);

        relationshipCreated.RelationshipName.Should().Be(relationshipOne.RelationshipName);
    }
}