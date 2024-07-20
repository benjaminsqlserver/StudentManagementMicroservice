namespace StudentManagement.Domain.Students.Dtos;

using StudentManagement.Resources;

public sealed class StudentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
