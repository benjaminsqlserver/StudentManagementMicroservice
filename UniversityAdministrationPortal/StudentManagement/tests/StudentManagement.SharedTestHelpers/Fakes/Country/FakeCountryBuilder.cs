namespace StudentManagement.SharedTestHelpers.Fakes.Country;

using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Countries.Models;

public class FakeCountryBuilder
{
    private CountryForCreation _creationData = new FakeCountryForCreation().Generate();

    public FakeCountryBuilder WithModel(CountryForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeCountryBuilder WithCountryName(string countryName)
    {
        _creationData.CountryName = countryName;
        return this;
    }
    
    public Country Build()
    {
        var result = Country.Create(_creationData);
        return result;
    }
}