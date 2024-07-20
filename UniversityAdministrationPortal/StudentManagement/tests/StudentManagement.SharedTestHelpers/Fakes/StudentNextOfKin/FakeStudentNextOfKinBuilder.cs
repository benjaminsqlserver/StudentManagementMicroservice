namespace StudentManagement.SharedTestHelpers.Fakes.StudentNextOfKin;

using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.Models;

public class FakeStudentNextOfKinBuilder
{
    private StudentNextOfKinForCreation _creationData = new FakeStudentNextOfKinForCreation().Generate();

    public FakeStudentNextOfKinBuilder WithModel(StudentNextOfKinForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithFirstName(string firstName)
    {
        _creationData.FirstName = firstName;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithLastName(string lastName)
    {
        _creationData.LastName = lastName;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithDateOfBirth(DateTime dateOfBirth)
    {
        _creationData.DateOfBirth = dateOfBirth;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithGenderId(Guid genderId)
    {
        _creationData.GenderId = genderId;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithPhoneNumber(string phoneNumber)
    {
        _creationData.PhoneNumber = phoneNumber;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithStudentID(Guid studentID)
    {
        _creationData.StudentID = studentID;
        return this;
    }
    
    public FakeStudentNextOfKinBuilder WithRelationshipID(Guid relationshipID)
    {
        _creationData.RelationshipID = relationshipID;
        return this;
    }
    
    public StudentNextOfKin Build()
    {
        var result = StudentNextOfKin.Create(_creationData);
        return result;
    }
}