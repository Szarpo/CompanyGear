using CompanyGear.Core.Enums;

namespace CompanyGear.Core.ValueObjects;

public sealed record RelationStatus
{
    public RelationStatusEnum Value { get; }

    public RelationStatus(RelationStatusEnum value)
    {

        Value = value;
    }


    public static implicit operator string(RelationStatus relationStatus) => relationStatus.Value.ToString();

    public static implicit operator RelationStatus(int value) => new RelationStatus((RelationStatusEnum)value);
    
}