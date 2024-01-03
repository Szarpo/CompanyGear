using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class Relation
{
    public Guid Id { get; }
    public Guid EmployeeId { get; set; }
    public Guid DeviceId { get; set; }
    public RelationStatus RelationStatus { get; set; }

    private Relation(Guid id, Guid employeeId, Guid deviceId, RelationStatus relationStatus)
    {
        Id = id;
        EmployeeId = employeeId;
        DeviceId = deviceId;
        RelationStatus = relationStatus;
    }
    
    public Relation() {}

    public static Relation CreateRelation(Guid employeeId, Guid gearId)
    {
        return new Relation(id: new Guid(), employeeId: employeeId, deviceId: gearId, relationStatus: new RelationStatus(0));
    }

    public void ArchiveRelation(RelationStatus relationStatus)
    {
        RelationStatus = relationStatus;
    }
    
}