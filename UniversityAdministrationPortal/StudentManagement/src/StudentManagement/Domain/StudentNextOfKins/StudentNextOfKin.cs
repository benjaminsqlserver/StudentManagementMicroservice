namespace StudentManagement.Domain.StudentNextOfKins;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.Relationships;
using StudentManagement.Domain.Genders;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.Students;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.StudentNextOfKins.Models;
using StudentManagement.Domain.StudentNextOfKins.DomainEvents;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.Models;


public class StudentNextOfKin : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public Guid GenderId { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public Guid StudentID { get; private set; }

    public Guid RelationshipID { get; private set; }

    public Student Student { get; }

    private readonly List<NextOfKinContactInformation> _nextOfKinContactInformations = new();
    public IReadOnlyCollection<NextOfKinContactInformation> NextOfKinContactInformations => _nextOfKinContactInformations.AsReadOnly();

    public Gender Gender { get; }

    public Relationship Relationship { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static StudentNextOfKin Create(StudentNextOfKinForCreation studentNextOfKinForCreation)
    {
        var newStudentNextOfKin = new StudentNextOfKin();

        newStudentNextOfKin.FirstName = studentNextOfKinForCreation.FirstName;
        newStudentNextOfKin.LastName = studentNextOfKinForCreation.LastName;
        newStudentNextOfKin.DateOfBirth = studentNextOfKinForCreation.DateOfBirth;
        newStudentNextOfKin.GenderId = studentNextOfKinForCreation.GenderId;
        newStudentNextOfKin.Email = studentNextOfKinForCreation.Email;
        newStudentNextOfKin.PhoneNumber = studentNextOfKinForCreation.PhoneNumber;
        newStudentNextOfKin.StudentID = studentNextOfKinForCreation.StudentID;
        newStudentNextOfKin.RelationshipID = studentNextOfKinForCreation.RelationshipID;

        newStudentNextOfKin.QueueDomainEvent(new StudentNextOfKinCreated(){ StudentNextOfKin = newStudentNextOfKin });
        
        return newStudentNextOfKin;
    }

    public StudentNextOfKin Update(StudentNextOfKinForUpdate studentNextOfKinForUpdate)
    {
        FirstName = studentNextOfKinForUpdate.FirstName;
        LastName = studentNextOfKinForUpdate.LastName;
        DateOfBirth = studentNextOfKinForUpdate.DateOfBirth;
        GenderId = studentNextOfKinForUpdate.GenderId;
        Email = studentNextOfKinForUpdate.Email;
        PhoneNumber = studentNextOfKinForUpdate.PhoneNumber;
        StudentID = studentNextOfKinForUpdate.StudentID;
        RelationshipID = studentNextOfKinForUpdate.RelationshipID;

        QueueDomainEvent(new StudentNextOfKinUpdated(){ Id = Id });
        return this;
    }

    public StudentNextOfKin AddNextOfKinContactInformation(NextOfKinContactInformation nextOfKinContactInformation)
    {
        _nextOfKinContactInformations.Add(nextOfKinContactInformation);
        return this;
    }
    
    public StudentNextOfKin RemoveNextOfKinContactInformation(NextOfKinContactInformation nextOfKinContactInformation)
    {
        _nextOfKinContactInformations.RemoveAll(x => x.Id == nextOfKinContactInformation.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected StudentNextOfKin() { } // For EF + Mocking
}
