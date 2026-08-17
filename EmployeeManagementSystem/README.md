Employee Management System

A C# Console Application built to practice and demonstrate important C# concepts through a practical Employee Management System.

The project combines Object-Oriented Programming, Collections, Generics, Delegates, Lambda Expressions, Events, Exception Handling, and manual data processing without LINQ in one complete application.

📌 Project Overview

The Employee Management System provides a simple environment for managing employees and departments.

The application allows users to:

Manage departments
Add employees
Process employee onboarding
Search employees by ID or name
Display employees by department
Calculate average salary
Generate department reports
Record and display unique skills
Promote employees to Managers
Track important actions
Filter employees using Delegates and Lambda Expressions
Receive notifications through Events

The application uses a console-based menu for interaction.

🎯 Project Goals

The main goal of this project is to understand how different C# features can be used together to solve real application problems.

The project demonstrates:

Object-Oriented Programming
Inheritance
Polymorphism
Method Overriding
Generics
Generic Result Handling
Collections
Delegates
Lambda Expressions
Events
Event Handlers
Exception Handling
Manual data processing
Console application design
🧱 Object-Oriented Design

The project contains the following main models:

Employee
   │
   └── Manager


Department
Employee

An Employee contains:

ID
Name
Department ID
Salary
Hire Date

The ToString() method is overridden to provide readable employee information when an employee is displayed.

Manager

Manager inherits from Employee.

An existing employee can be promoted to a Manager through the promotion functionality.

Department

A department contains:

ID
Name



📦 C# Collections

The project intentionally uses five different collection types, with each collection having a specific responsibility.

Collection	Purpose
List<Employee>	Stores active employees
Dictionary<int, Department>	Stores departments by ID
Queue<Employee>	Manages employee onboarding
Stack<string>	Maintains action history
HashSet<string>	Stores unique skills
List<Employee>

The employee list stores employees who have completed onboarding.

It is used for:

Searching employees
Filtering employees
Salary calculations
Department reports
Displaying employees
Employee promotion

Dictionary<int, Department>

Departments are stored using their ID as the key.

Example:

1 → .Net
2 → Angular
3 → Flutter

The dictionary provides an organized way to manage departments and locate departments by ID.

Queue<Employee>

New employees are added to an onboarding queue before becoming active employees.

The queue follows the FIFO — First In, First Out principle.

Employee A
Employee B
Employee C
    ↓
Employee A is processed first

The onboarding process uses Enqueue() and Dequeue().

Stack<string>

The application maintains an action history using a Stack.

Actions such as the following are recorded:

Department added
Employee added to onboarding
Employee completed onboarding
Employee promoted
Skill recorded

The Stack follows LIFO — Last In, First Out, so the newest action appears first.

HashSet<string>

Employee skills are stored in a HashSet<string>.

This allows the application to maintain a collection of unique skills and prevent duplicate skill values from being added.

🧩 Generic Result<T>

The project uses a generic Result<T> class to represent the result of operations.

Instead of returning only a bool, operations can provide:

Success status
Message
Result object

For example:

Result<Employee> result = company.AddEmployee(employee);


if (result.Success)
{
    Console.WriteLine("Employee added successfully.");
}
else
{
    Console.WriteLine(result.Message);
}

The same approach is used when adding departments:

Result<Department>

This provides a consistent way of handling successful and failed operations.

🚀 Employee Onboarding

When an employee is added successfully, the employee is placed into the onboarding queue.

Add Employee
     ↓
Validate Employee
     ↓
Onboarding Queue
     ↓
Process Onboarding
     ↓
Active Employees

When onboarding is processed:

The employee is removed from the queue.
The employee is added to the active employee list.
The action is recorded in the history.
The EmployeeOnboarded event is raised.
📢 Events

The project demonstrates C# Events using:

EventHandler<EmployeeEventArgs>

Two employee lifecycle events are implemented:

EmployeeOnboarded
EmployeePromoted
EmployeeOnboarded

When an employee completes onboarding, the Company class raises the event.

EmployeeOnboarded?.Invoke(
    this,
    new EmployeeEventArgs(employee)
);

Program.cs subscribes to the event and displays a notification.

EmployeePromoted

When an employee is successfully promoted to Manager, the application raises:

EmployeePromoted?.Invoke(
    this,
    new EmployeeEventArgs(manager)
);

The event subscriber then displays a promotion notification.

The event flow can be represented as:

Company
   ↓
Raises Event
   ↓
EventHandler
   ↓
Program.cs
   ↓
Console Notification
⬆️ Employee Promotion

The system allows an existing employee to become a Manager.

The promotion process:

Find Employee
      ↓
Check if Already Manager
      ↓
Create Manager
      ↓
Copy Employee Information
      ↓
Replace Employee in List
      ↓
Record Action History
      ↓
Raise EmployeePromoted Event

The employee information transferred includes:

ID
Name
Salary
Department ID
Hire Date

If the employee is already a Manager, the promotion is rejected.

🔌 Delegates

The project defines an EmployeeFilter delegate:

public delegate bool EmployeeFilter(Employee employee);

The delegate represents a method that:

Receives an Employee
Returns a bool

It is used by:

FilterEmployees(EmployeeFilter filter)

This allows the same filtering method to work with different conditions.

🔍 Lambda Expressions

The project demonstrates multiple Lambda Expressions with the EmployeeFilter delegate.

Find Managers
emp => emp is Manager
Find Employees With Salary Above 10,000
emp => emp.Salary > 10000

Both conditions can be passed to the same:

FilterEmployees()

method.

The filtering itself is performed manually using foreach.

Lambda Expression
       ↓
EmployeeFilter Delegate
       ↓
FilterEmployees()
       ↓
foreach
       ↓
Filtered Employees

This demonstrates how Delegates and Lambda Expressions can be combined to create reusable filtering logic.

🔎 Employee Search

The application supports manual employee searching.

Search by ID
SearchEmployeeById(int id)
Search by Name
SearchEmployeeByName(string name)

The searches are implemented using manual iteration rather than LINQ.

🏢 Employees by Department

The application can display all employees belonging to a specific department.

The department is located using the department collection, and employees are then checked manually using their DepartmentId.

No LINQ is required for this operation.

💰 Average Salary

The application calculates the average salary manually.

The process:

Check whether employees exist.
Loop through all employees.
Add each employee's salary.
Divide the total salary by the number of employees.

Conceptually:

Total Salary
     ÷
Employee Count
     =
Average Salary

The calculation does not use LINQ's .Average().

📊 Department Report

The system generates a report showing the number of employees in each department.

Example:

DepartmentName : .Net
Employee Count : 2


DepartmentName : Angular
Employee Count : 1


DepartmentName : Flutter
Employee Count : 1

The report is implemented using manual loops rather than LINQ grouping.

🛠️ Skill Management

Users can record skills for employees.

The application uses:

HashSet<string>

to maintain unique skills.

Users can also display all registered skills.

📜 Action History

Important operations are stored in:

Stack<string>

Examples include:

Employee 'Mohamed' was promoted to Manager.
Skill 'C#' recorded for employee 'Mohamed'.
The Employee Saleh completed onboarding.
Employee 'Mahmoud' added to onboarding queue.
Department '.Net' added.

Since the history uses a Stack, the latest action is displayed first.

🌱 Seed Data

The application includes seed data for easier testing.

Departments
ID  Name
1   .Net
2   Angular
3   Flutter
Employees
ID  Name
1   Mohamed
2   Saleh
3   Eslam
4   Mahmoud

The seeded employees are added to the onboarding queue and processed automatically.

Initial skills include:

C#
JavaScript
ASP.NET CORE
HTML
🖥️ Console Menu

The application provides the following menu:

=============================
Employee Management System
=============================


1- Show Departments
2- Add Department
3- Add Employee
4- Process Onboarding
5- Search Employee By Id
6- Search Employee By Name
7- Show Employee By Department
8- Calculate Average Salary
9- Department Report
10- Show Action History
11- Record Skill
12- Show All Skills
13- Promote Employee
14- Filter Employees


0- exit
🛡️ Error Handling

The application handles invalid operations and invalid user input.

Examples include:

Invalid menu options
Invalid employee IDs
Duplicate employee IDs
Duplicate department IDs
Non-existent departments
Non-existent employees
Empty onboarding queue
Duplicate skills
Promoting an employee who is already a Manager

The main menu also uses exception handling to prevent invalid input from terminating the application unexpectedly.

🗂️ Project Structure
EmployeeManagementSystem/
│
├── Models/
│   ├── Employee.cs
│   ├── Manager.cs
│   └── Department.cs
│
├── Common/
│   └── Result.cs
│
├── Delegates/
│   └── EmployeeFilter.cs
│
├── Events/
│   └── EmployeeEventArgs.cs
│
├── Services/
│   └── Company.cs
│
└── Program.cs
▶️ Getting Started
Prerequisites
.NET SDK
Visual Studio or another C# IDE
Clone the Repository
git clone https://github.com/MohamedElsayed03/EmployeeManagementSystem.git
Navigate to the Project
cd EmployeeManagementSystem
Run the Application
dotnet run

You can also open the project in Visual Studio and run it using the debugger

Requirements Coverage
Feature	Status
Employee Model	✅
Manager Inheritance	✅
Department Model	✅
Result<T>	✅
List<T>	✅
Dictionary<TKey,TValue>	✅
Queue<T>	✅
Stack<T>	✅
HashSet<T>	✅
Employee Onboarding	✅
Employee Promotion	✅
EmployeeOnboarded Event	✅
EmployeePromoted Event	✅
EmployeeEventArgs	✅
EmployeeFilter Delegate	✅
Lambda Expressions	✅
Multiple Lambda Filters	✅
Manual Employee Search	✅
Manual Filtering	✅
Average Salary Without LINQ	✅
Department Report Without LINQ	✅
Unique Skills	✅
Action History	✅
Seed Data	✅
Console Menu	✅
Invalid Input Handling	✅
💡 Design Philosophy

Each C# feature in this project has a specific responsibility.

List        → Employees
Dictionary  → Departments
Queue       → Employee Onboarding
Stack       → Action History
HashSet     → Unique Skills
Generics    → Operation Results
Delegate    → Filtering Logic
Lambda      → Dynamic Filter Conditions
Events      → Employee Lifecycle Notifications

The goal is to demonstrate practical usage of C# features, rather than using them only as isolated examples.

🛠️ Technologies
C#
.NET
Console Application
Object-Oriented Programming
Generics
Collections
Delegates
Lambda Expressions
Events
Exception Handling
👨‍💻 Author
Mohamed Elsayed

C# / .NET learning project focused on practical implementation of:

OOP → Collections → Generics → Delegates → Lambda Expressions → Events

⭐ Key Highlights
✅ Five C# collections used for meaningful purposes
✅ Generic Result<T> implementation
✅ FIFO employee onboarding
✅ LIFO action history
✅ Unique skill management
✅ Employee → Manager promotion
✅ Employee lifecycle events
✅ Reusable delegate-based filtering
✅ Multiple Lambda Expressions
✅ Manual searching and calculations
✅ Department reporting without LINQ
✅ Seed data for testing
✅ Interactive console menu
✅ Exception handling and validation
📄 License

This project was created for educational and learning purposes.