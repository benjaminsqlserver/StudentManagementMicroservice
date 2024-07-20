namespace StudentManagement.SharedTestHelpers.Fakes.StudentContactInformation;

using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Models;

public class FakeStudentContactInformationBuilder
{
    private StudentContactInformationForCreation _creationData = new FakeStudentContactInformationForCreation().Generate();

    public FakeStudentContactInformationBuilder WithModel(StudentContactInformationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeStudentContactInformationBuilder WithHouseAddress(string houseAddress)
    {
        _creationData.HouseAddress = houseAddress;
        return this;
    }
    
    public FakeStudentContactInformationBuilder WithCity(string city)
    {
        _creationData.City = city;
        return this;
    }
    
    public FakeStudentContactInformationBuilder WithState(string state)
    {
        _creationData.State = state;
        return this;
    }
    
    public FakeStudentContactInformationBuilder WithZipCode(string zipCode)
    {
        _creationData.ZipCode = zipCode;
        return this;
    }
    
    public FakeStudentContactInformationBuilder WithCountryID(Guid countryID)
    {
        _creationData.CountryID = countryID;
        return this;
    }
    
    public FakeStudentContactInformationBuilder WithStudentID(Guid studentID)
    {
        _creationData.StudentID = studentID;
        return this;
    }
    
    public StudentContactInformation Build()
    {
        var result = StudentContactInformation.Create(_creationData);
        return result;
    }
}