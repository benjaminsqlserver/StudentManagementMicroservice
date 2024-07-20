namespace StudentManagement.SharedTestHelpers.Fakes.Relationship;

using AutoBogus;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Relationships.Dtos;

public sealed class FakeRelationshipForUpdateDto : AutoFaker<RelationshipForUpdateDto>
{
    public FakeRelationshipForUpdateDto()
    {
    }
}