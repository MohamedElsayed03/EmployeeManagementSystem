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




        public bool AddDepartment(Department department)
        {
            if(departments.ContainsKey(department.Id))
            {
                Console.WriteLine("This Id is already exist.");
                return false;
            }

            departments.Add(department.Id, department);
            actionHistory.Push($"Department '{department.Name}' added.");

            return true;
        }

        public void ShowDepartments()
        {
            foreach (var item in departments)
            {
                Console.WriteLine($"[ Id : {item.Value.Id} --> Name : {item.Value.Name} ]");
                
            }
        }
        public bool AddEmployee(Employee employee)
        {
            foreach (var item in employees)
            {
                
                
                if (employee.Id == item.Id)
                    Console.WriteLine("Employee already exists.");
                    return false;
            }
            onboardingQueue.Enqueue(employee);
            actionHistory.Push($"Employee '{employee.Name}' added to onboarding queue.");

            Console.WriteLine("Employee added to onboarding queue successfully.");

            return true;
                           
        }
   
        public void ProcessOnboarding()
        {
            if(onboardingQueue.Count == 0)
            {
                Console.WriteLine("No employees waiting for onboarding.");
                return;
            }

            Employee employee = onboardingQueue.Dequeue();

            employees.Add(employee);
         
            actionHistory.Push($"The Employee {employee.Name} completed onboarding.");
            
            Console.WriteLine("The Employee Added successfully");

        }

        public bool RecordSkill(int employeeId, string skill)
        {
            Employee? employee1 = null;
            foreach (var item in employees)
            {
                if (employeeId ==item.Id)
                {

                    employee1 = item;
                    break;
                }

            }
            if (employee1 == null)
            {
                Console.WriteLine("Employee not found.");
                return false;
            }


            if (!skills.Add(skill))
            {
                Console.WriteLine("Can't Add This Skill ,Becouse it's already existed");
                return false;
            }
        
            actionHistory.Push($"Skill '{skill}' recorded for employee '{employee1.Name}'.");
            Console.WriteLine("The Skill Added successfully");
            return true ;
        }

    }
}
