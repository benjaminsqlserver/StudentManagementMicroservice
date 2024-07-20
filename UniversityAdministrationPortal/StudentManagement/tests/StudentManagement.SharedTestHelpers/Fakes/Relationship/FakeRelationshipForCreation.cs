namespace StudentManagement.SharedTestHelpers.Fakes.Relationship;

using AutoBogus;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.Models;

public sealed class FakeRelationshipForCreation : AutoFaker<RelationshipForCreation>
{
    public FakeRelationshipForCreation()
    {
    }
}