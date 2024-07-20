namespace StudentManagement.SharedTestHelpers.Fakes.Student;

using AutoBogus;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Dtos;

public sealed class FakeStudentForUpdateDto : AutoFaker<StudentForUpdateDto>
{
    public FakeStudentForUpdateDto()
    {
    }
}