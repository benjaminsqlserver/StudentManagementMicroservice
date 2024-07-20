namespace StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;

using AutoBogus;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Dtos;

public sealed class FakeStudentContactInformationForUpdateDto : AutoFaker<StudentContactInformationForUpdateDto>
{
    public FakeStudentContactInformationForUpdateDto()
    {
    }
}