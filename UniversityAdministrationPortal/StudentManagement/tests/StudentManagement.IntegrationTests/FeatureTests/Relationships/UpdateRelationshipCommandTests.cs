namespace StudentManagement.IntegrationTests.FeatureTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.Domain.Relationships.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateRelationshipCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_relationship_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var relationship = new FakeRelationshipBuilder().Build();
        await testingServiceScope.InsertAsync(relationship);
        var updatedRelationshipDto = new FakeRelationshipForUpdateDto().Generate();

        // Act
        var command = new UpdateRelationship.Command(relationship.Id, updatedRelationshipDto);
        await testingServiceScope.SendAsync(command);
        var updatedRelationship = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Relationships
                .FirstOrDefaultAsync(r => r.Id == relationship.Id));

        // Assert
        updatedRelationship.RelationshipName.Should().Be(updatedRelationshipDto.RelationshipName);
    }
}