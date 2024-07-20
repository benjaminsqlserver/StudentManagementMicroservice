namespace StudentManagement.IntegrationTests.FeatureTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.Domain.Relationships.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteRelationshipCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_relationship_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var relationship = new FakeRelationshipBuilder().Build();
        await testingServiceScope.InsertAsync(relationship);

        // Act
        var command = new DeleteRelationship.Command(relationship.Id);
        await testingServiceScope.SendAsync(command);
        var relationshipResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Relationships
                .CountAsync(r => r.Id == relationship.Id));

        // Assert
        relationshipResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_relationship_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteRelationship.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_relationship_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var relationship = new FakeRelationshipBuilder().Build();
        await testingServiceScope.InsertAsync(relationship);

        // Act
        var command = new DeleteRelationship.Command(relationship.Id);
        await testingServiceScope.SendAsync(command);
        var deletedRelationship = await testingServiceScope.ExecuteDbContextAsync(db => db.Relationships
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == relationship.Id));

        // Assert
        deletedRelationship?.IsDeleted.Should().BeTrue();
    }
}