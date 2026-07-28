using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using System.Diagnostics;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Company company = new Company();        
            company.SeedData();

            while (true)
            {
                Console.Clear();
                try {
                    PrintMenu();

                    var result = int.Parse(Console.ReadLine());


                    switch (result)
                    {
                        
                        case 1:
                            company.ShowDepartments();
                            break;
                        case 2:
                            HandleAddDepartment(company);
                            break;
                        case 3:
                            HandleAddEmployee(company);
                            break;
                        case 4:
                            HandelProcessOnboarding(company);
                            break;                            
                        case 5:
                            HandelSearchEmployeeById(company);
                            break;
                        case 6:
                            HandelSearchEmployeeByName(company);
                            break;
                        case 7:
                            HandelShowEmployeesByDepartment(company);
                            break;                          
                        case 8:
                            HandelCalculateAverageSalary(company);
                            break;                           
                        case 9:
                            HandelDepartmentReport(company);
                            break;                            
                        case 10:
                            HandleShowActionHistory(company);
                            break;                            
                        case 11:
                            HandleRecordSkill(company);
                            break;
                        case 12:
                            HandleShowAllSkills(company);
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Operation ,Please choose a number from the menu.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }            
                Console.ReadKey();
                 
            }

        }
        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("Employee Management System");
            Console.WriteLine("=============================");
            Console.WriteLine("1- Show Departments");
            Console.WriteLine("2- Add Department");
            Console.WriteLine("3- Add Employee");
            Console.WriteLine("4- Process Onboarding");
            Console.WriteLine("5- Search Employee By Id");
            Console.WriteLine("6- Search Employee By Name");
            Console.WriteLine("7- Show Employee By Department");
            Console.WriteLine("8- Calculate Average Salary");
            Console.WriteLine("9- Department Report");
            Console.WriteLine("10- Show Action History");
            Console.WriteLine("11- Record Skill");
            Console.WriteLine("12- Show All Skills");
            Console.WriteLine();
            Console.WriteLine("0- exit");
            Console.WriteLine("_________________________________");
            Console.WriteLine("Choose an Option :");

        }
        private static void HandleAddEmployee(Company company)
        {
            Console.WriteLine("Name :");
            var name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Id : ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Department Id : ");
            int departmentid = int.Parse(Console.ReadLine());

            Console.WriteLine("Salary :");
            decimal salary = decimal.Parse(Console.ReadLine());

            

            Employee employee = new Employee(id,departmentid,name ,salary,DateTime.Now);
            
            company.AddEmployee(employee);
            Console.WriteLine("Employee added to onboarding queue successfully.");


        }
        private static void HandelProcessOnboarding(Company company)
        {
            company.ProcessOnboarding();
            Console.WriteLine("The Employee Added successfully");

        }
        private static void HandelSearchEmployeeByName(Company company)
        {
            Console.WriteLine("Enter The Name : ");
            string name = Console.ReadLine() ?? string.Empty;
          Employee? employee  = company.SearchEmployeeByName(name);

            if(employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }
            Console.WriteLine("Employee found");
            Console.WriteLine(employee);
        }
        private static void HandelSearchEmployeeById(Company company)
        {
            Console.WriteLine("Enter The Id : ");
            int id = int.Parse(Console.ReadLine());
            Employee? employee = company.SearchEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return; 
            }
            Console.WriteLine("Employee found");
            Console.WriteLine(employee);
        }
        private static void HandelShowEmployeesByDepartment(Company company)
        {
            Console.WriteLine("Enter Department Id : ");
            int departmentid = int.Parse(Console.ReadLine());
            company.ShowEmployeesByDepartment(departmentid);
        }
        private static void HandelCalculateAverageSalary(Company company)
        {
           decimal avgsalary = company.CalculateAverageSalary();

            Console.WriteLine($"Average Salary : {avgsalary}");
        }
        private static void HandelDepartmentReport(Company company)
        {
            Console.WriteLine("Department Report");
            Console.WriteLine("-------------------------\n");
            company.DepartmentReport();
            Console.WriteLine("-------------------------\n");
        }
        private static void HandleShowActionHistory(Company company)
        {
            Console.WriteLine("Action History");
            Console.WriteLine("-------------------------\n");
            company.ShowActionHistory();
            Console.WriteLine("-------------------------\n");
        }
        private static void HandleShowAllSkills(Company company)
        {
            Console.WriteLine("All Skills");
            Console.WriteLine("--------------\n");
            company.ShowAllSkills();
            Console.WriteLine("--------------\n");
        }
        private static void HandleRecordSkill(Company company)
        {
            Console.WriteLine("Enter Employee Id :"); 
            int employeeid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Skill :");
            string skill = Console.ReadLine()?? string.Empty;
           
            company.RecordSkill(employeeid,skill);
            Console.WriteLine("The Skill Added successfully");
        }
        private static void HandleAddDepartment(Company company)
        {
            Console.WriteLine("Enter The Name OF the Dpartment : ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter The Id OF the Dpartment : ");
            int id  = int.Parse(Console.ReadLine());

            Department department = new Department() { Name  = name, Id = id };

          bool add =  company.AddDepartment(department);
            if(add)
            {
                Console.WriteLine($"The Department [ Id :{id} --> Name : {name} ] added successfully");
            }

        }
    }
}
