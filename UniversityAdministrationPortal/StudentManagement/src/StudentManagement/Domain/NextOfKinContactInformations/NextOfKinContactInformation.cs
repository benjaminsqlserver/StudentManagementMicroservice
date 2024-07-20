namespace StudentManagement.Domain.NextOfKinContactInformations;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.Countries;
using StudentManagement.Domain.StudentNextOfKins;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.NextOfKinContactInformations.Models;
using StudentManagement.Domain.NextOfKinContactInformations.DomainEvents;


public class NextOfKinContactInformation : BaseEntity
{
    public string HouseAddress { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public string ZipCode { get; private set; }

    public Guid CountryID { get; private set; }

    public Guid NextOfKinID { get; private set; }

    public StudentNextOfKin StudentNextOfKin { get; }

    public Country Country { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static NextOfKinContactInformation Create(NextOfKinContactInformationForCreation nextOfKinContactInformationForCreation)
    {
        var newNextOfKinContactInformation = new NextOfKinContactInformation();

        newNextOfKinContactInformation.HouseAddress = nextOfKinContactInformationForCreation.HouseAddress;
        newNextOfKinContactInformation.City = nextOfKinContactInformationForCreation.City;
        newNextOfKinContactInformation.State = nextOfKinContactInformationForCreation.State;
        newNextOfKinContactInformation.ZipCode = nextOfKinContactInformationForCreation.ZipCode;
        newNextOfKinContactInformation.CountryID = nextOfKinContactInformationForCreation.CountryID;
        newNextOfKinContactInformation.NextOfKinID = nextOfKinContactInformationForCreation.NextOfKinID;

        newNextOfKinContactInformation.QueueDomainEvent(new NextOfKinContactInformationCreated(){ NextOfKinContactInformation = newNextOfKinContactInformation });
        
        return newNextOfKinContactInformation;
    }

    public NextOfKinContactInformation Update(NextOfKinContactInformationForUpdate nextOfKinContactInformationForUpdate)
    {
        HouseAddress = nextOfKinContactInformationForUpdate.HouseAddress;
        City = nextOfKinContactInformationForUpdate.City;
        State = nextOfKinContactInformationForUpdate.State;
        ZipCode = nextOfKinContactInformationForUpdate.ZipCode;
        CountryID = nextOfKinContactInformationForUpdate.CountryID;
        NextOfKinID = nextOfKinContactInformationForUpdate.NextOfKinID;

        QueueDomainEvent(new NextOfKinContactInformationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected NextOfKinContactInformation() { } // For EF + Mocking
}
