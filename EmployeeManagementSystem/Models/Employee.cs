using System;
 
namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public Employee(int id, int departmentId, string name, decimal salary, DateTime hireDate)
        {
            Id = id;
            DepartmentId = departmentId;
            Name = name;
            Salary = salary;
            HireDate = hireDate;
        }

        public Employee() { }
        public int Id { get; set; }
        public int DepartmentId { get; set; }

       public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateTime HireDate{ get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Department Id: {DepartmentId}, Salary: {Salary}, Hire Date: {HireDate:d}";
        }
    }
}
