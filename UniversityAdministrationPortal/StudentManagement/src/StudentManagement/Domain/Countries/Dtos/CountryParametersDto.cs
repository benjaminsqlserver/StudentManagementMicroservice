namespace StudentManagement.Domain.Countries.Dtos;

using StudentManagement.Resources;

public sealed class CountryParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
