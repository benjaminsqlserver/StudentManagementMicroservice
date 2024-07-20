namespace StudentManagement.Domain.Genders.Services;

using StudentManagement.Domain.Genders;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface IGenderRepository : IGenericRepository<Gender>
{
}

public sealed class GenderRepository(StudentManagementDbContext dbContext) : GenericRepository<Gender>(dbContext), IGenderRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
