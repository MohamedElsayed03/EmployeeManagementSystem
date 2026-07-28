
# Employee Management System

A simple C# Console Application for managing employees and departments using C# collections.

## Features

- Add departments
- Add employees
- Process employee onboarding using Queue
- Search employees by ID
- Search employees by name
- Show employees by department
- Calculate average salary
- Generate department report
- Record employee skills
- Display all skills
- View action history using Stack

## Collections Used

- List<Employee>
- Dictionary<int, Department>
- Queue<Employee>
- Stack<string>
- HashSet<string>

## Project Structure

```
EmployeeManagementSystem
│
├── Models
│   ├── Employee.cs
│   ├── Department.cs
│   └── Manager.cs
│
├── Services
│   └── Company.cs
│
└── Program.cs
```

## Technologies

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)

## How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the project.
4. Run the application.

## Notes

- The project stores data in memory only.
- Seed data is loaded automatically when the application starts.
- No database or LINQ is used.

## Author

Mohamed Elsayed 
