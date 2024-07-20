namespace StudentManagement.SharedTestHelpers.Fakes.Student;

using AutoBogus;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Dtos;

public sealed class FakeStudentForCreationDto : AutoFaker<StudentForCreationDto>
{
    public FakeStudentForCreationDto()
    {
    }
}