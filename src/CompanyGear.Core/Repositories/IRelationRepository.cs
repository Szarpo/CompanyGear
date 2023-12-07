using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IRelationRepository
{
     Task CreateRelationEmployeeToGear(Relation relation);
}