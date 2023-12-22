using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record RelationStatus
{
    public RelationStatusEnum Value { get; }

    public RelationStatus(RelationStatusEnum value)
    {
        if (!Enum.IsDefined(typeof(RelationStatusEnum), value))
        {
            throw new InvalidRelationStatusException(value.ToString());
        }
        Value = value;
    }


    public static implicit operator string(RelationStatus relationStatus) => relationStatus.Value.ToString();

    public static implicit operator RelationStatus(int value) => new RelationStatus((RelationStatusEnum)value);
    
}