using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IRelationRepository
{
     Task CreateRelationEmployeeToGear(Relation relation);
     Task ArchiveRelation(Relation relation);
     Task Delete(Relation relation);
     Task<Relation> GetById(Guid id);
     Task<bool> IsExistId(Guid relationId);



}