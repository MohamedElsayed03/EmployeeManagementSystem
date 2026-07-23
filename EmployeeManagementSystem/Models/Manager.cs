using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public class Manager : Employee
    {
        public List <Employee> TeamMembers { get; } = new List <Employee> ();
    }
}
