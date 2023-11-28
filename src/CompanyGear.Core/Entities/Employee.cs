using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class Employee
{
    public Guid EmployeeId { get;}
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; } 
    public EmployeeNumber EmployeeNumber { get; private set; }
    public Department Department { get;  private set; }
    

    private Employee(Guid id, string firstName, string lastName, string employeeNumber, string department)
    {
        EmployeeId = id;
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

    public void Update(FirstName firstName, LastName lastName, EmployeeNumber employeeNumber, Department department)
    {
        FirstName = firstName;
        LastName = lastName;
        EmployeeNumber = employeeNumber;
        Department = department;
    }

}