namespace StudentManagement.SharedTestHelpers.Fakes.Relationship;

using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.Models;

public class FakeRelationshipBuilder
{
    private RelationshipForCreation _creationData = new FakeRelationshipForCreation().Generate();

    public FakeRelationshipBuilder WithModel(RelationshipForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeRelationshipBuilder WithRelationshipName(string relationshipName)
    {
        _creationData.RelationshipName = relationshipName;
        return this;
    }
    
    public Relationship Build()
    {
        var result = Relationship.Create(_creationData);
        return result;
    }
}