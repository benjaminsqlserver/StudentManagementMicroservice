namespace StudentManagement.Domain.NextOfKinContactInformations.Dtos;

using StudentManagement.Resources;

public sealed class NextOfKinContactInformationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
