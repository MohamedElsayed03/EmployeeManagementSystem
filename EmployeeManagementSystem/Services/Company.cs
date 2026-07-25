using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class Company
    {
        private readonly List<Employee> employees = new List<Employee>();
        
        private readonly Dictionary<int,Department> departments = new Dictionary<int,Department>();

        private readonly Stack<string> actionHistory = new Stack<string>();
        
        private readonly Queue<Employee> onboardingQueue = new Queue<Employee>();
        
        private readonly HashSet<string> skills = new HashSet<string>();

    }
}
