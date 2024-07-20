namespace StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;

using AutoBogus;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Dtos;

public sealed class FakeStudentContactInformationForCreationDto : AutoFaker<StudentContactInformationForCreationDto>
{
    public FakeStudentContactInformationForCreationDto()
    {
    }
}