namespace StudentManagement.UnitTests.Domain.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class UpdateRelationshipTests
{
    private readonly Faker _faker;

    public UpdateRelationshipTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_relationship()
    {
        // Arrange
        var relationship = new FakeRelationshipBuilder().Build();
        var updatedRelationship = new FakeRelationshipForUpdate().Generate();
        
        // Act
        relationship.Update(updatedRelationship);

        // Assert
        relationship.RelationshipName.Should().Be(updatedRelationship.RelationshipName);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var relationship = new FakeRelationshipBuilder().Build();
        var updatedRelationship = new FakeRelationshipForUpdate().Generate();
        relationship.DomainEvents.Clear();
        
        // Act
        relationship.Update(updatedRelationship);

        // Assert
        relationship.DomainEvents.Count.Should().Be(1);
        relationship.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(RelationshipUpdated));
    }
}