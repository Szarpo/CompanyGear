using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class Employee
{
    public Guid Id { get;  }
    public FirstName FirstName { get; }
    public LastName LastName { get; } 
    public EmployeeNumber EmployeeNumber { get; }
    public Department Department { get;  }
    

    private Employee(Guid id, string firstName, string lastName, int employeeNumber, string department)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        EmployeeNumber = employeeNumber;
        Department = department;
    }

    public Employee()
    {
        
    }

    public static Employee Create(FirstName firstName, LastName lastName, EmployeeNumber employeeNumber, Department department)
    {
        return new Employee(Guid.NewGuid(), firstName, lastName, employeeNumber, department);
    }
    
}