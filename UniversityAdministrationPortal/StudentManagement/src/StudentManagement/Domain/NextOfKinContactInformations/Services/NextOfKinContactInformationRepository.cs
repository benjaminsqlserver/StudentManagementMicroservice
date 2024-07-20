namespace StudentManagement.Domain.NextOfKinContactInformations.Services;

using StudentManagement.Domain.NextOfKinContactInformations;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface INextOfKinContactInformationRepository : IGenericRepository<NextOfKinContactInformation>
{
}

public sealed class NextOfKinContactInformationRepository(StudentManagementDbContext dbContext) : GenericRepository<NextOfKinContactInformation>(dbContext), INextOfKinContactInformationRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
