namespace StudentManagement.Domain.Relationships;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.StudentNextOfKins;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.Relationships.Models;
using StudentManagement.Domain.Relationships.DomainEvents;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.Models;


public class Relationship : BaseEntity
{
    public string RelationshipName { get; private set; }

    private readonly List<StudentNextOfKin> _studentNextOfKins = new();
    public IReadOnlyCollection<StudentNextOfKin> StudentNextOfKins => _studentNextOfKins.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Relationship Create(RelationshipForCreation relationshipForCreation)
    {
        var newRelationship = new Relationship();

        newRelationship.RelationshipName = relationshipForCreation.RelationshipName;

        newRelationship.QueueDomainEvent(new RelationshipCreated(){ Relationship = newRelationship });
        
        return newRelationship;
    }

    public Relationship Update(RelationshipForUpdate relationshipForUpdate)
    {
        RelationshipName = relationshipForUpdate.RelationshipName;

        QueueDomainEvent(new RelationshipUpdated(){ Id = Id });
        return this;
    }

    public Relationship AddStudentNextOfKin(StudentNextOfKin studentNextOfKin)
    {
        _studentNextOfKins.Add(studentNextOfKin);
        return this;
    }
    
    public Relationship RemoveStudentNextOfKin(StudentNextOfKin studentNextOfKin)
    {
        _studentNextOfKins.RemoveAll(x => x.Id == studentNextOfKin.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Relationship() { } // For EF + Mocking
}
