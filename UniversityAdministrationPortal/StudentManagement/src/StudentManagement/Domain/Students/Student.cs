namespace StudentManagement.Domain.Students;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentContactInformations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.Students.Models;
using StudentManagement.Domain.Students.DomainEvents;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Models;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.Models;


public class Student : BaseEntity
{
    public string MatriculationNumber { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public Guid GenderId { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    private readonly List<StudentContactInformation> _studentContactInformations = new();
    public IReadOnlyCollection<StudentContactInformation> StudentContactInformations => _studentContactInformations.AsReadOnly();

    private readonly List<StudentNextOfKin> _studentNextOfKins = new();
    public IReadOnlyCollection<StudentNextOfKin> StudentNextOfKins => _studentNextOfKins.AsReadOnly();

    public Gender Gender { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Student Create(StudentForCreation studentForCreation)
    {
        var newStudent = new Student();

        newStudent.MatriculationNumber = studentForCreation.MatriculationNumber;
        newStudent.FirstName = studentForCreation.FirstName;
        newStudent.LastName = studentForCreation.LastName;
        newStudent.DateOfBirth = studentForCreation.DateOfBirth;
        newStudent.GenderId = studentForCreation.GenderId;
        newStudent.Email = studentForCreation.Email;
        newStudent.PhoneNumber = studentForCreation.PhoneNumber;

        newStudent.QueueDomainEvent(new StudentCreated(){ Student = newStudent });
        
        return newStudent;
    }

    public Student Update(StudentForUpdate studentForUpdate)
    {
        MatriculationNumber = studentForUpdate.MatriculationNumber;
        FirstName = studentForUpdate.FirstName;
        LastName = studentForUpdate.LastName;
        DateOfBirth = studentForUpdate.DateOfBirth;
        GenderId = studentForUpdate.GenderId;
        Email = studentForUpdate.Email;
        PhoneNumber = studentForUpdate.PhoneNumber;

        QueueDomainEvent(new StudentUpdated(){ Id = Id });
        return this;
    }

    public Student AddStudentContactInformation(StudentContactInformation studentContactInformation)
    {
        _studentContactInformations.Add(studentContactInformation);
        return this;
    }
    
    public Student RemoveStudentContactInformation(StudentContactInformation studentContactInformation)
    {
        _studentContactInformations.RemoveAll(x => x.Id == studentContactInformation.Id);
        return this;
    }

    public Student AddStudentNextOfKin(StudentNextOfKin studentNextOfKin)
    {
        _studentNextOfKins.Add(studentNextOfKin);
        return this;
    }
    
    public Student RemoveStudentNextOfKin(StudentNextOfKin studentNextOfKin)
    {
        _studentNextOfKins.RemoveAll(x => x.Id == studentNextOfKin.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Student() { } // For EF + Mocking
}
