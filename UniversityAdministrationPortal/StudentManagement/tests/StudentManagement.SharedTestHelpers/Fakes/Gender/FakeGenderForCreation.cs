namespace StudentManagement.SharedTestHelpers.Fakes.Gender;

using AutoBogus;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Models;

public sealed class FakeGenderForCreation : AutoFaker<GenderForCreation>
{
    public FakeGenderForCreation()
    {
    }
}