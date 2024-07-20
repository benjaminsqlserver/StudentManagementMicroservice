namespace StudentManagement.Domain.StudentNextOfKins.Dtos;

using StudentManagement.Resources;

public sealed class StudentNextOfKinParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
