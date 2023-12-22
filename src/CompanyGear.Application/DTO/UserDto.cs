using System.Data;
using CompanyGear.Core.Enums;

namespace CompanyGear.Application.DTO;

public class UserDto
{
    public Guid Id { get; set; }
    public string? Login { get; set; }
    public string? Fullname { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Role { get; set; }
}