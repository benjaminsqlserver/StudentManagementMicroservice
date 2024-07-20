namespace StudentManagement.Domain.StudentContactInformations;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.Students;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.StudentContactInformations.Models;
using StudentManagement.Domain.StudentContactInformations.DomainEvents;


public class StudentContactInformation : BaseEntity
{
    public string HouseAddress { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public string ZipCode { get; private set; }

    public Guid CountryID { get; private set; }

    public Guid StudentID { get; private set; }

    public Student Student { get; }

    public Country Country { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static StudentContactInformation Create(StudentContactInformationForCreation studentContactInformationForCreation)
    {
        var newStudentContactInformation = new StudentContactInformation();

        newStudentContactInformation.HouseAddress = studentContactInformationForCreation.HouseAddress;
        newStudentContactInformation.City = studentContactInformationForCreation.City;
        newStudentContactInformation.State = studentContactInformationForCreation.State;
        newStudentContactInformation.ZipCode = studentContactInformationForCreation.ZipCode;
        newStudentContactInformation.CountryID = studentContactInformationForCreation.CountryID;
        newStudentContactInformation.StudentID = studentContactInformationForCreation.StudentID;

        newStudentContactInformation.QueueDomainEvent(new StudentContactInformationCreated(){ StudentContactInformation = newStudentContactInformation });
        
        return newStudentContactInformation;
    }

    public StudentContactInformation Update(StudentContactInformationForUpdate studentContactInformationForUpdate)
    {
        HouseAddress = studentContactInformationForUpdate.HouseAddress;
        City = studentContactInformationForUpdate.City;
        State = studentContactInformationForUpdate.State;
        ZipCode = studentContactInformationForUpdate.ZipCode;
        CountryID = studentContactInformationForUpdate.CountryID;
        StudentID = studentContactInformationForUpdate.StudentID;

        QueueDomainEvent(new StudentContactInformationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected StudentContactInformation() { } // For EF + Mocking
}
