namespace StudentManagement.SharedTestHelpers.Fakes.Gender;

using AutoBogus;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Models;

public sealed class FakeGenderForUpdate : AutoFaker<GenderForUpdate>
{
    public FakeGenderForUpdate()
    {
    }
}