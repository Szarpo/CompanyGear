namespace CompanyGear.Core.Entities;

public class Relation
{
    public Guid Id { get; }
    public Guid EmployeeId { get; set; }
    public Guid GearId { get; set; }

    private Relation(Guid id, Guid employeeId, Guid gearId)
    {
        Id = id;
        EmployeeId = employeeId;
        GearId = gearId;
    }
    
    public Relation() {}

    public static Relation CreateRelation(Guid employeeId, Guid gearId)
    {
        return new Relation(id: new Guid(), employeeId: employeeId, gearId: gearId);
    }
}