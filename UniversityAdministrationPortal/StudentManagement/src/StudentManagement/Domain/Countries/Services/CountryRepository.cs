namespace StudentManagement.Domain.Countries.Services;

using StudentManagement.Domain.Countries;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface ICountryRepository : IGenericRepository<Country>
{
}

public sealed class CountryRepository(StudentManagementDbContext dbContext) : GenericRepository<Country>(dbContext), ICountryRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
