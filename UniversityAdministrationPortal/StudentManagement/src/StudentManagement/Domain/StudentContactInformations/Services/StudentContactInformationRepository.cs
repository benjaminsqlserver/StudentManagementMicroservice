namespace StudentManagement.Domain.StudentContactInformations.Services;

using StudentManagement.Domain.StudentContactInformations;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface IStudentContactInformationRepository : IGenericRepository<StudentContactInformation>
{
}

public sealed class StudentContactInformationRepository(StudentManagementDbContext dbContext) : GenericRepository<StudentContactInformation>(dbContext), IStudentContactInformationRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
