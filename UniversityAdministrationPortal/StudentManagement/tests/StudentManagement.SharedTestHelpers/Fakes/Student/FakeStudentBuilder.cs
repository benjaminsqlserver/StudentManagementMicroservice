namespace StudentManagement.SharedTestHelpers.Fakes.Student;

using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Models;

public class FakeStudentBuilder
{
    private StudentForCreation _creationData = new FakeStudentForCreation().Generate();

    public FakeStudentBuilder WithModel(StudentForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeStudentBuilder WithMatriculationNumber(string matriculationNumber)
    {
        _creationData.MatriculationNumber = matriculationNumber;
        return this;
    }
    
    public FakeStudentBuilder WithFirstName(string firstName)
    {
        _creationData.FirstName = firstName;
        return this;
    }
    
    public FakeStudentBuilder WithLastName(string lastName)
    {
        _creationData.LastName = lastName;
        return this;
    }
    
    public FakeStudentBuilder WithDateOfBirth(DateTime dateOfBirth)
    {
        _creationData.DateOfBirth = dateOfBirth;
        return this;
    }
    
    public FakeStudentBuilder WithGenderId(Guid genderId)
    {
        _creationData.GenderId = genderId;
        return this;
    }
    
    public FakeStudentBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeStudentBuilder WithPhoneNumber(string phoneNumber)
    {
        _creationData.PhoneNumber = phoneNumber;
        return this;
    }
    
    public Student Build()
    {
        var result = Student.Create(_creationData);
        return result;
    }
}