namespace StudentManagement.Domain.StudentNextOfKins.Mappings;

using StudentManagement.Domain.StudentNextOfKins.Dtos;
using StudentManagement.Domain.StudentNextOfKins.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class StudentNextOfKinMapper
{
    public static partial StudentNextOfKinForCreation ToStudentNextOfKinForCreation(this StudentNextOfKinForCreationDto studentNextOfKinForCreationDto);
    public static partial StudentNextOfKinForUpdate ToStudentNextOfKinForUpdate(this StudentNextOfKinForUpdateDto studentNextOfKinForUpdateDto);
    public static partial StudentNextOfKinDto ToStudentNextOfKinDto(this StudentNextOfKin studentNextOfKin);
    public static partial IQueryable<StudentNextOfKinDto> ToStudentNextOfKinDtoQueryable(this IQueryable<StudentNextOfKin> studentNextOfKin);
}