namespace StudentManagement.SharedTestHelpers.Fakes.Country;

using AutoBogus;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.Models;

public sealed class FakeCountryForCreation : AutoFaker<CountryForCreation>
{
    public FakeCountryForCreation()
    {
    }
}