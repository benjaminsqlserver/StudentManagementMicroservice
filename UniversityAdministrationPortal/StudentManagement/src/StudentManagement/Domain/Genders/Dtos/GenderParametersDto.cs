namespace StudentManagement.Domain.Genders.Dtos;

using StudentManagement.Resources;

public sealed class GenderParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
