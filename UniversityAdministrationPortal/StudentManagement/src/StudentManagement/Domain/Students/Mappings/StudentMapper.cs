namespace StudentManagement.Domain.Students.Mappings;

using StudentManagement.Domain.Students.Dtos;
using StudentManagement.Domain.Students.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class StudentMapper
{
    public static partial StudentForCreation ToStudentForCreation(this StudentForCreationDto studentForCreationDto);
    public static partial StudentForUpdate ToStudentForUpdate(this StudentForUpdateDto studentForUpdateDto);
    public static partial StudentDto ToStudentDto(this Student student);
    public static partial IQueryable<StudentDto> ToStudentDtoQueryable(this IQueryable<Student> student);
}