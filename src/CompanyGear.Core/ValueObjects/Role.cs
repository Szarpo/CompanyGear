using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record Role
{
    public RoleEnum Value { get; }

    public Role(RoleEnum value)
    {
        if (!Enum.IsDefined(typeof(RoleEnum), value))
        {
            throw new InvalidRoleException(value.ToString());
        }
        
        Value = value;
    }

    public static implicit operator string(Role role) => role.Value.ToString();
    public static implicit operator Role(int role) => new Role((RoleEnum)role);
}