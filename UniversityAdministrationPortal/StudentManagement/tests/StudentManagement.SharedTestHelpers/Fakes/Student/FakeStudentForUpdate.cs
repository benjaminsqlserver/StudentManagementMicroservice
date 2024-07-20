namespace StudentManagement.SharedTestHelpers.Fakes.Student;

using AutoBogus;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Models;

public sealed class FakeStudentForUpdate : AutoFaker<StudentForUpdate>
{
    public FakeStudentForUpdate()
    {
    }
}