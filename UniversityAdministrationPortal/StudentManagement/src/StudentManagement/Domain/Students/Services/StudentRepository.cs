namespace StudentManagement.Domain.Students.Services;

using StudentManagement.Domain.Students;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface IStudentRepository : IGenericRepository<Student>
{
}

public sealed class StudentRepository(StudentManagementDbContext dbContext) : GenericRepository<Student>(dbContext), IStudentRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
