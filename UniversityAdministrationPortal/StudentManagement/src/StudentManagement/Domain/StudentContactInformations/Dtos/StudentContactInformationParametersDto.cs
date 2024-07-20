namespace StudentManagement.Domain.StudentContactInformations.Dtos;

using StudentManagement.Resources;

public sealed class StudentContactInformationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
