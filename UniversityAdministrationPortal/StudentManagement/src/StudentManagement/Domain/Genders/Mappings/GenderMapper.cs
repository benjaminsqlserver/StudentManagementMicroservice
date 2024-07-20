namespace StudentManagement.Domain.Genders.Mappings;

using StudentManagement.Domain.Genders.Dtos;
using StudentManagement.Domain.Genders.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class GenderMapper
{
    public static partial GenderForCreation ToGenderForCreation(this GenderForCreationDto genderForCreationDto);
    public static partial GenderForUpdate ToGenderForUpdate(this GenderForUpdateDto genderForUpdateDto);
    public static partial GenderDto ToGenderDto(this Gender gender);
    public static partial IQueryable<GenderDto> ToGenderDtoQueryable(this IQueryable<Gender> gender);
}