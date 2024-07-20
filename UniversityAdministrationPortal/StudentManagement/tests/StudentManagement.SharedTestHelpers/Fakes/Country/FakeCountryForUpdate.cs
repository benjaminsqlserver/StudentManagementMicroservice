namespace StudentManagement.SharedTestHelpers.Fakes.Country;

using AutoBogus;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.Models;

public sealed class FakeCountryForUpdate : AutoFaker<CountryForUpdate>
{
    public FakeCountryForUpdate()
    {
    }
}