namespace StudentManagement.SharedTestHelpers.Fakes.Gender;

using AutoBogus;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Dtos;

public sealed class FakeGenderForUpdateDto : AutoFaker<GenderForUpdateDto>
{
    public FakeGenderForUpdateDto()
    {
    }
}