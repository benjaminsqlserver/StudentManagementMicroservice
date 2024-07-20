namespace StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;

using AutoBogus;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Models;

public sealed class FakeStudentContactInformationForCreation : AutoFaker<StudentContactInformationForCreation>
{
    public FakeStudentContactInformationForCreation()
    {
    }
}