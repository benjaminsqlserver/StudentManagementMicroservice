namespace StudentManagement.Domain.Relationships.Mappings;

using StudentManagement.Domain.Relationships.Dtos;
using StudentManagement.Domain.Relationships.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class RelationshipMapper
{
    public static partial RelationshipForCreation ToRelationshipForCreation(this RelationshipForCreationDto relationshipForCreationDto);
    public static partial RelationshipForUpdate ToRelationshipForUpdate(this RelationshipForUpdateDto relationshipForUpdateDto);
    public static partial RelationshipDto ToRelationshipDto(this Relationship relationship);
    public static partial IQueryable<RelationshipDto> ToRelationshipDtoQueryable(this IQueryable<Relationship> relationship);
}