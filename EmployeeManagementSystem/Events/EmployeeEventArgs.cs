using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Events
{
    public class EmployeeEventArgs : EventArgs
    {
        public Employee Employee { get; }
        public EmployeeEventArgs(Employee employee)
        {
            Employee = employee;
        }
         
    }
}
