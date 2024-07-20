namespace StudentManagement.SharedTestHelpers.Fakes.NextOfKinContactInformation;

using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.Models;

public class FakeNextOfKinContactInformationBuilder
{
    private NextOfKinContactInformationForCreation _creationData = new FakeNextOfKinContactInformationForCreation().Generate();

    public FakeNextOfKinContactInformationBuilder WithModel(NextOfKinContactInformationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeNextOfKinContactInformationBuilder WithHouseAddress(string houseAddress)
    {
        _creationData.HouseAddress = houseAddress;
        return this;
    }
    
    public FakeNextOfKinContactInformationBuilder WithCity(string city)
    {
        _creationData.City = city;
        return this;
    }
    
    public FakeNextOfKinContactInformationBuilder WithState(string state)
    {
        _creationData.State = state;
        return this;
    }
    
    public FakeNextOfKinContactInformationBuilder WithZipCode(string zipCode)
    {
        _creationData.ZipCode = zipCode;
        return this;
    }
    
    public FakeNextOfKinContactInformationBuilder WithCountryID(Guid countryID)
    {
        _creationData.CountryID = countryID;
        return this;
    }
    
    public FakeNextOfKinContactInformationBuilder WithNextOfKinID(Guid nextOfKinID)
    {
        _creationData.NextOfKinID = nextOfKinID;
        return this;
    }
    
    public NextOfKinContactInformation Build()
    {
        var result = NextOfKinContactInformation.Create(_creationData);
        return result;
    }
}