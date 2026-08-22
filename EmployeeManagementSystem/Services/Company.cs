using EmployeeManagementSystem.Common;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using EmployeeManagementSystem.Events;
using EmployeeManagementSystem.Delegates;

namespace EmployeeManagementSystem.Services
{
    public class Company
    {
        private readonly List<Employee> employees = new List<Employee>();
        
        private readonly Dictionary<int,Department> departments = new Dictionary<int,Department>();

        private readonly Stack<string> actionHistory = new Stack<string>();
        
        private readonly Queue<Employee> onboardingQueue = new Queue<Employee>();
        
        private readonly HashSet<string> skills = new HashSet<string>();

        public event EventHandler<EmployeeEventArgs> EmployeeOnboarded;
        public event EventHandler<EmployeeEventArgs> EmployeePromoted;


        public Result<Department> AddDepartment(Department department)
        {
            if(departments.ContainsKey(department.Id))
            {
                return Result<Department>.Fail("This Id is already exist.");
            }
           
            departments.Add(department.Id, department);
            actionHistory.Push($"Department '{department.Name}' added.");

            return Result<Department>.Ok(department, "Departmnet Add successfully.");
        }

        public void ShowDepartments()
        {
            foreach (var item in departments)
            {
                Console.WriteLine($"[ Id : {item.Value.Id} --> Name : {item.Value.Name} ]");
                
            }
        }
        public Result<Employee> AddEmployee(Employee employee)
        {
            if(!departments.ContainsKey(employee.DepartmentId))
            {
                return Result<Employee>.Fail("Department does not exist.");
            }
            foreach (var item in employees)
            {


                if (employee.Id == item.Id)
                {
                   return Result<Employee>.Fail("Employee already exists.");
                }
                
            }
            foreach (var item in onboardingQueue)
            {
                if (employee.Id == item.Id)
                {                 
                    return Result<Employee>.Fail("Employee is already in onboarding queue. ض");
                }
            }
            onboardingQueue.Enqueue(employee);
            actionHistory.Push($"Employee '{employee.Name}' added to onboarding queue.");


            return Result<Employee>.Ok(employee, "Employee Add successfully");
                           
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
            
            EmployeeOnboarded?.Invoke(this,new EmployeeEventArgs(employee));
        }
        public void PromoteEmployee(int employeeid)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if(employees[i].Id == employeeid)
                {
                    if (employees[i] is Manager)
                    {
                        Console.WriteLine("Already Manager");
                        return;
                    }
                    Employee employee = employees[i];

                    Manager manager = new Manager();

                    manager.Id = employeeid;
                    manager.Name = employee.Name;
                    manager.Salary = employee.Salary;
                    manager.DepartmentId = employee.DepartmentId;
                    manager.HireDate = employee.HireDate;
                    employees[i] = manager;

                    actionHistory.Push( $"Employee '{employee.Name}' was promoted to Manager.");

                    EmployeePromoted?.Invoke(this, new EmployeeEventArgs(manager));

                    return;
                }                
            }
            Console.WriteLine("Employee not found");
        }
        public List<Employee> FilterEmployees(EmployeeFilter filter)
        {
            List<Employee> list = new List<Employee>();

            foreach (var employee in employees)
            {
                if(filter(employee))
                {
                   list.Add(employee);
                }
                
            }
            return list;
             
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

            if(!employee1.AddSkill(skill))
            {
                Console.WriteLine("Can't add This Skill To The Employee ,Becouse Already has it.");
                return false;
            }

            if (!skills.Add(skill))
            {
                Console.WriteLine("Can't Add This Skill ,Becouse it's already existed");
                return false;
            }

            actionHistory.Push($"Skill '{skill}' recorded for employee '{employee1.Name}'.");
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
        }
        public void ShowActionHistory()
        {
            if(actionHistory.Count ==0)
            {
                Console.WriteLine("No Action Found.");
                return;
            }          
            foreach (var action in actionHistory)
            {
                Console.WriteLine(action);

            }          
        }

        public void ShowAllSkills()
        {
            if(skills.Count ==0)
            {
                Console.WriteLine("No Skills Found.");
                return;
            }
            foreach (var skill in skills)
            {
                Console.WriteLine(skill);
            }         
        }
        public void SeedData()
        {

            Department BackEnd = new Department()
            {
                Id = 1,
                Name = ".Net"
            };

            Department Frontend = new Department()
            {
                Id = 2,
                Name = "Angular"
            };
            Department Mobile = new Department()
            {
                Id = 3,
                Name = "Flutter"
            };


            AddDepartment(BackEnd);
            AddDepartment(Frontend);
            AddDepartment(Mobile);

            Employee employee1 = new Employee()
            {
                Name = "Mohamed",
                Id = 1,
                DepartmentId = 1,
                HireDate = DateTime.Now.AddYears(-1),
                Salary = 18000m

            };
            Employee employee2 = new Employee()
            {
                Name = "Saleh",
                Id = 2,
                DepartmentId = 2,
                HireDate = DateTime.Now,
                Salary = 20000m

            };
            Employee employee3 = new Employee()
            {
                Name = "Eslam",
                Id = 3,
                DepartmentId = 1,
                HireDate = DateTime.Now.AddYears(-3),
                Salary = 28000m

            };
            Employee employee4 = new Employee()
            {
                Name = "Mahmoud",
                Id = 4,
                DepartmentId = 3,
                HireDate = DateTime.Now.AddYears(-1),
                Salary = 21000m

            };

            AddEmployee(employee1);
            AddEmployee(employee2);
            AddEmployee(employee3);
            AddEmployee(employee4);

            ProcessOnboarding();
            ProcessOnboarding();
            ProcessOnboarding();
            ProcessOnboarding();

            RecordSkill(1, "C#");
            RecordSkill(2, "JavaScript");
            RecordSkill(3, "ASP.NET CORE");
            RecordSkill(4, "HTML");

        }
    }
}
