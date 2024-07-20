namespace StudentManagement.UnitTests.Domain.Relationships;

using StudentManagement.SharedTestHelpers.Fakes.Relationship;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = StudentManagement.Exceptions.ValidationException;

public class CreateRelationshipTests
{
    private readonly Faker _faker;

    public CreateRelationshipTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_relationship()
    {
        // Arrange
        var relationshipToCreate = new FakeRelationshipForCreation().Generate();
        
        // Act
        var relationship = Relationship.Create(relationshipToCreate);

        // Assert
        relationship.RelationshipName.Should().Be(relationshipToCreate.RelationshipName);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var relationshipToCreate = new FakeRelationshipForCreation().Generate();
        
        // Act
        var relationship = Relationship.Create(relationshipToCreate);

        // Assert
        relationship.DomainEvents.Count.Should().Be(1);
        relationship.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(RelationshipCreated));
    }
}