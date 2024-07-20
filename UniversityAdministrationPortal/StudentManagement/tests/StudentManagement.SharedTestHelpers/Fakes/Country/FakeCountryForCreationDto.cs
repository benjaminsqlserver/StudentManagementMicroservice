namespace StudentManagement.SharedTestHelpers.Fakes.Country;

using AutoBogus;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.Dtos;

public sealed class FakeCountryForCreationDto : AutoFaker<CountryForCreationDto>
{
    public FakeCountryForCreationDto()
    {
    }
}