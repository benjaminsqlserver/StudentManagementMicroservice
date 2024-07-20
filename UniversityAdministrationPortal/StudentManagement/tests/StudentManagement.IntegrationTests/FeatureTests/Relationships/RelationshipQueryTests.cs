namespace StudentManagement.IntegrationTests.FeatureTests.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.Domain.Relationships.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class RelationshipQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_relationship_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var relationshipOne = new FakeRelationshipBuilder().Build();
        await testingServiceScope.InsertAsync(relationshipOne);

        // Act
        var query = new GetRelationship.Query(relationshipOne.Id);
        var relationship = await testingServiceScope.SendAsync(query);

        // Assert
        relationship.RelationshipName.Should().Be(relationshipOne.RelationshipName);
    }

    [Fact]
    public async Task get_relationship_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetRelationship.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}