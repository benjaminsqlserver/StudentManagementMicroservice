namespace StudentManagement.SharedTestHelpers.Fakes.Gender;

using AutoBogus;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Dtos;

public sealed class FakeGenderForCreationDto : AutoFaker<GenderForCreationDto>
{
    public FakeGenderForCreationDto()
    {
    }
}