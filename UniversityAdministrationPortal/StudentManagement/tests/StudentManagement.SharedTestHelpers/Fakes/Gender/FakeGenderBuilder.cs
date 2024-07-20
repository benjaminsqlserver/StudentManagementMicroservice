namespace StudentManagement.SharedTestHelpers.Fakes.Gender;

using StudentManagement.Domain.Genders;
using StudentManagement.Domain.Genders.Models;

public class FakeGenderBuilder
{
    private GenderForCreation _creationData = new FakeGenderForCreation().Generate();

    public FakeGenderBuilder WithModel(GenderForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeGenderBuilder WithGenderName(string genderName)
    {
        _creationData.GenderName = genderName;
        return this;
    }
    
    public Gender Build()
    {
        var result = Gender.Create(_creationData);
        return result;
    }
}