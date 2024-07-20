namespace StudentManagement.SharedTestHelpers.Fakes.Relationship;

using AutoBogus;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.Models;

public sealed class FakeRelationshipForUpdate : AutoFaker<RelationshipForUpdate>
{
    public FakeRelationshipForUpdate()
    {
    }
}