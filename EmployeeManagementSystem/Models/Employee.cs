using System;
 
namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }

       public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateTime HireDate{ get; set; }

    }
}
