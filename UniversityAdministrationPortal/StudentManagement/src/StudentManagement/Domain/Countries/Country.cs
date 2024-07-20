namespace StudentManagement.Domain.Countries;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.StudentContactInformations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.Countries.Models;
using StudentManagement.Domain.Countries.DomainEvents;
using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Domain.StudentContactInformations.Models;
using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Domain.NextOfKinContactInformations.Models;


public class Country : BaseEntity
{
    public string CountryName { get; private set; }

    private readonly List<StudentContactInformation> _studentContactInformations = new();
    public IReadOnlyCollection<StudentContactInformation> StudentContactInformations => _studentContactInformations.AsReadOnly();

    private readonly List<NextOfKinContactInformation> _nextOfKinContactInformations = new();
    public IReadOnlyCollection<NextOfKinContactInformation> NextOfKinContactInformations => _nextOfKinContactInformations.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Country Create(CountryForCreation countryForCreation)
    {
        var newCountry = new Country();

        newCountry.CountryName = countryForCreation.CountryName;

        newCountry.QueueDomainEvent(new CountryCreated(){ Country = newCountry });
        
        return newCountry;
    }

    public Country Update(CountryForUpdate countryForUpdate)
    {
        CountryName = countryForUpdate.CountryName;

        QueueDomainEvent(new CountryUpdated(){ Id = Id });
        return this;
    }

    public Country AddStudentContactInformation(StudentContactInformation studentContactInformation)
    {
        _studentContactInformations.Add(studentContactInformation);
        return this;
    }
    
    public Country RemoveStudentContactInformation(StudentContactInformation studentContactInformation)
    {
        _studentContactInformations.RemoveAll(x => x.Id == studentContactInformation.Id);
        return this;
    }

    public Country AddNextOfKinContactInformation(NextOfKinContactInformation nextOfKinContactInformation)
    {
        _nextOfKinContactInformations.Add(nextOfKinContactInformation);
        return this;
    }
    
    public Country RemoveNextOfKinContactInformation(NextOfKinContactInformation nextOfKinContactInformation)
    {
        _nextOfKinContactInformations.RemoveAll(x => x.Id == nextOfKinContactInformation.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Country() { } // For EF + Mocking
}
