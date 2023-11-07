namespace CompanyGear.Core.Entities;

public class Employee
{
    public Guid Id { get;  }
    public string FirstName { get; }
    public string LastName { get; } 
    public int EmployeeNumber { get; }
    public string Department { get;  }
    

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

    public static Employee Create(Guid id, string firstName, string lastName, int employeeNumber, string department)
    {
        return new Employee(Guid.NewGuid(), firstName, lastName, employeeNumber, department);
    }
    
}