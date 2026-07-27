using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;

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
            if(!departments.ContainsKey(employee.DepartmentId))
            {
                Console.WriteLine("Department does not exist.");
                return false;
            }
            foreach (var item in employees)
            {


                if (employee.Id == item.Id)
                {
                    Console.WriteLine("Employee already exists.");
                    return false;
                }
                
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

        public Employee? SearchEmployeeByName(string name)
        {
            foreach (var item in employees)
            {
                if(name == item.Name)
                { 
                    return item;
                }

            }
            return null;

        }
        public Employee? SearchEmployeeById(int id)
        {
            foreach (var item in employees)
            {
                if (id == item.Id)
                {
                    return item;
                }

            }
            return null;

        }
        public void ShowEmployeesByDepartment(int departmentId)
        {
            Department? department = null;
            
            foreach (var item in departments)
            {
                if(item.Key == departmentId)
                {
                    department = item.Value;
                    break;
                }
            }

            if (department == null)
            {
                Console.WriteLine("The Department is not found");
                return;
            }
            
            bool found =false;

            Console.WriteLine($"Department: {department.Name}");
            Console.WriteLine("--------------------------------");

            foreach (Employee employee in employees)
            {
                if (employee.DepartmentId == departmentId)
                {
                    Console.WriteLine(employee);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("NO Employees in this Department.");
            }
        }
        public decimal CalculateAverageSalary()
        {
            decimal TotalSalary =0m;
            
            if (employees.Count == 0)
            {
                return 0;
            }

            foreach (var employee in employees)
            {
                TotalSalary += employee.Salary;                       
            }

            return (TotalSalary / employees.Count);

        }
        public void DepartmentReport()
        {
            Console.WriteLine("Department Report");
            Console.WriteLine("-------------------------\n");
            foreach (var department in departments)
            {            
                int counter = 0;
                foreach (var item in employees)
                {
                    if (item.DepartmentId == department.Key)
                    {
                        counter++;
                    }
                }

                Console.WriteLine($"DepartmentName : {department.Value.Name}\n" +
                    $"Employee Count : {counter}\n");
            }
            Console.WriteLine("\n-------------------------\n");      

        }
        public void ShowActionHistory()
        {
            if(actionHistory.Count ==0)
            {
                Console.WriteLine("No Action Found.");
                return;
            }
            Console.WriteLine("Action History");
            Console.WriteLine("\n-------------------------\n");
            foreach (var action in actionHistory)
            {
                Console.WriteLine(action);

            }
            Console.WriteLine("\n-------------------------\n");
        }

        public void ShowAllSkills()
        {
            if(skills.Count ==0)
            {
                Console.WriteLine("No Skills Found.");
                return;
            }
            Console.WriteLine("All Skills");
            Console.WriteLine("\n--------------\n");

            foreach (var skill in skills)
            {
                Console.WriteLine(skill);
            }
            Console.WriteLine("\n--------------\n");

        }
    }
}
