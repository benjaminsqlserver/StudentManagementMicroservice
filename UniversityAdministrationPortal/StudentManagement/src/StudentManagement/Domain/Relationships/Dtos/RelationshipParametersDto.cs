namespace StudentManagement.Domain.Relationships.Dtos;

using StudentManagement.Resources;

public sealed class RelationshipParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
