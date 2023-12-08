using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class RelationRepository : IRelationRepository
{
    private readonly CompanyGearDbContext _dbContext;
    private readonly DbSet<Relation> _relations;

    public RelationRepository(CompanyGearDbContext dbContext)
    {
        _dbContext = dbContext;
        _relations = dbContext.Relations;
    }

    public async Task CreateRelationEmployeeToGear(Relation relation)
    {
        await _relations.AddAsync(relation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Relation relation)
    {
        _relations.Remove(relation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Relation> GetById(Guid id) => await _relations.FirstOrDefaultAsync(x => x.Id == id);
}