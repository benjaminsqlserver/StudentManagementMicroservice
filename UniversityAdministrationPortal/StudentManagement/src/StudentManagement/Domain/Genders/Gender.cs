namespace StudentManagement.Domain.Genders;

using System.ComponentModel.DataAnnotations;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.Students;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using StudentManagement.Exceptions;
using StudentManagement.Domain.Genders.Models;
using StudentManagement.Domain.Genders.DomainEvents;
using StudentManagement.Domain.Students;
using StudentManagement.Domain.Students.Models;
using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Domain.StudentNextOfKins.Models;


public class Gender : BaseEntity
{
    public string GenderName { get; private set; }

    private readonly List<Student> _students = new();
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

    private readonly List<StudentNextOfKin> _studentNextOfKins = new();
    public IReadOnlyCollection<StudentNextOfKin> StudentNextOfKins => _studentNextOfKins.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Gender Create(GenderForCreation genderForCreation)
    {
        var newGender = new Gender();

        newGender.GenderName = genderForCreation.GenderName;

        newGender.QueueDomainEvent(new GenderCreated(){ Gender = newGender });
        
        return newGender;
    }

    public Gender Update(GenderForUpdate genderForUpdate)
    {
        GenderName = genderForUpdate.GenderName;

        QueueDomainEvent(new GenderUpdated(){ Id = Id });
        return this;
    }

    public Gender AddStudent(Student student)
    {
        _students.Add(student);
        return this;
    }
    
    public Gender RemoveStudent(Student student)
    {
        _students.RemoveAll(x => x.Id == student.Id);
        return this;
    }

    public Gender AddStudentNextOfKin(StudentNextOfKin studentNextOfKin)
    {
        _studentNextOfKins.Add(studentNextOfKin);
        return this;
    }
    
    public Gender RemoveStudentNextOfKin(StudentNextOfKin studentNextOfKin)
    {
        _studentNextOfKins.RemoveAll(x => x.Id == studentNextOfKin.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Gender() { } // For EF + Mocking
}
