namespace StudentManagement.Domain.StudentNextOfKins.Services;

using StudentManagement.Domain.StudentNextOfKins;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface IStudentNextOfKinRepository : IGenericRepository<StudentNextOfKin>
{
}

public sealed class StudentNextOfKinRepository(StudentManagementDbContext dbContext) : GenericRepository<StudentNextOfKin>(dbContext), IStudentNextOfKinRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
