namespace StudentManagement.Domain.Relationships.Services;

using StudentManagement.Domain.Relationships;
using StudentManagement.Databases;
using StudentManagement.Services;

public interface IRelationshipRepository : IGenericRepository<Relationship>
{
}

public sealed class RelationshipRepository(StudentManagementDbContext dbContext) : GenericRepository<Relationship>(dbContext), IRelationshipRepository
{
    private readonly StudentManagementDbContext _dbContext = dbContext;
}  
