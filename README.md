# 👨‍💼 Employee Management System

<div align="center">

### A C# Console Application for Employee & Department Management

**A practical C# project demonstrating OOP, Collections, Generics, Delegates, Events, and structured application design.**

<br/>

[![C#](https://img.shields.io/badge/C%23-Programming-512BD4?style=for-the-badge\&logo=csharp\&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-Console%20Application-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)](https://dotnet.microsoft.com/)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=for-the-badge\&logo=github\&logoColor=white)](https://github.com/MohamedElsayed03/EmployeeManagementSystem)

</div>

---

## 📖 About The Project

The **Employee Management System** is a C# Console Application designed to simulate common employee and department management operations inside a company.

The main purpose of this project was not only to build an employee management system, but also to apply important C# concepts in a practical application.

The project combines:

* Object-Oriented Programming
* Collections
* Generics
* Delegates
* Events
* Custom Event Arguments
* Searching and Filtering
* Employee Onboarding
* Department Management
* Reporting
* Action History
* Employee Skills Management
* Employee Promotion

The application currently works with **in-memory data**, allowing the focus to remain on C# programming concepts and application logic.

---

# ✨ Features

## 👨‍💼 Employee Management

* Add new employees
* Search employees by ID
* Search employees by name
* Display employees by department
* Record employee skills
* Display all employee skills
* Promote employees
* Filter employees
* Calculate average salary

## 🏢 Department Management

* Show departments
* Add departments
* Associate employees with departments
* Display employees by department
* Generate department reports

## ⚙️ Employee Processing

* Process employee onboarding using `Queue<T>`
* Track application actions using `Stack<T>`
* Store unique skills using `HashSet<T>`
* Use events to notify the application when employee-related actions occur

---

# 🖥️ Console Menu

The application provides an interactive console menu that allows the user to access all major features.

```text
==============================
Employee Management System
==============================

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

0- Exit
```

### Menu Operations

| Option | Operation               | Description                                 |
| -----: | ----------------------- | ------------------------------------------- |
|      1 | Show Departments        | Display available departments               |
|      2 | Add Department          | Create a new department                     |
|      3 | Add Employee            | Add a new employee                          |
|      4 | Process Onboarding      | Process employees waiting for onboarding    |
|      5 | Search By ID            | Find an employee using their ID             |
|      6 | Search By Name          | Find employees using their name             |
|      7 | Employees By Department | Display employees belonging to a department |
|      8 | Average Salary          | Calculate the average employee salary       |
|      9 | Department Report       | Generate a report for a department          |
|     10 | Action History          | Display previous application actions        |
|     11 | Record Skill            | Add a skill to an employee                  |
|     12 | Show All Skills         | Display employee skills                     |
|     13 | Promote Employee        | Promote an employee                         |
|     14 | Filter Employees        | Filter employees according to criteria      |
|      0 | Exit                    | Close the application                       |

---

# 🧠 C# Concepts Demonstrated

One of the main goals of this project was to use C# concepts **inside a real application**, rather than using them only in isolated examples.

---

## 🔹 1. Object-Oriented Programming

The application uses OOP to model real-world entities.

The main classes include:

```text
Employee
Department
Manager
Company
```

For example:

```text
Company
   │
   ├── Departments
   │
   └── Employees
          │
          ├── Employee Information
          ├── Skills
          └── Department
```

This makes the application easier to organize and maintain.

---

# 📦 2. Collections

Different collections are used depending on the problem being solved.

| Collection                 | Role in the Project                            |
| -------------------------- | ---------------------------------------------- |
| `List<T>`                  | Store and manage employees and other objects   |
| `Dictionary<TKey, TValue>` | Access departments using a key                 |
| `Queue<T>`                 | Process employee onboarding in FIFO order      |
| `Stack<T>`                 | Store and display action history in LIFO order |
| `HashSet<T>`               | Store unique employee skills                   |

### Why different collections?

Because each collection solves a different problem.

```text
List       → General collection
Dictionary → Key → Value lookup
Queue      → First In → First Out
Stack      → Last In → First Out
HashSet    → Unique values
```

---

# 🧬 3. Generics

Generics are heavily used throughout the project to make collections **strongly typed, reusable, and type-safe**.

Examples:

```csharp
List<Employee>

Dictionary<int, Department>

Queue<Employee>

Stack<string>

HashSet<string>
```

### Why Generics?

Instead of creating separate collections for every type, generics allow the same collection structure to work with different data types.

For example:

```csharp
List<Employee>
```

means:

> A list that contains `Employee` objects.

While:

```csharp
Queue<Employee>
```

means:

> A queue specifically designed to process `Employee` objects.

### Generic Concept

```text
             Generic Collection
                    │
          ┌─────────┴─────────┐
          │                   │
       Employee            Department
          │                   │
          ▼                   ▼
   List<Employee>    List<Department>
```

This provides compile-time type safety and makes the code easier to understand.

---

# 🎯 4. Delegates

The project demonstrates **Delegates** as a way to pass methods as values and allow the application to work with different behaviors dynamically.

A delegate can be viewed as:

```text
Method
  │
  ▼
Delegate
  │
  ▼
Passed to another method
  │
  ▼
Executed when needed
```

### Role of Delegates in the Project

Delegates are useful when an operation needs to receive **behavior** rather than only data.

For example, filtering employees can be represented conceptually as:

```text
Employee Collection
       │
       ▼
   Filter Operation
       │
       ▼
     Delegate
       │
       ▼
 Employee Condition
       │
       ▼
Matching Employees
```

This makes the operation more flexible because the filtering logic can be supplied separately from the method performing the filtering.

### Why Use Delegates?

Delegates provide:

* Flexible method passing
* Reusable behavior
* Separation between operation and logic
* A foundation for events and callbacks

---

# ⚡ 5. Events

The project also demonstrates **Events**, which are used to notify other parts of the application when an employee-related action occurs.

The project contains:

```text
Events/
└── EmployeeEventArgs.cs
```

This custom `EventArgs` class allows additional information to be passed when an event is raised.

### Event Flow

```text
Employee Action
      │
      ▼
   Event Raised
      │
      ▼
 Event Arguments
      │
      ▼
 Event Handler
      │
      ▼
Application Response
```

For example, an employee operation can trigger an event, and the subscribed handler can react to that operation.

### Why Events?

Events are useful for creating a **notification mechanism** between different parts of an application without tightly coupling them together.

---

# 🔗 Delegate + Event Relationship

One of the important concepts demonstrated by this project is the relationship between **Delegates and Events**.

Conceptually:

```text
                 Delegate
                    │
                    ▼
                 Event
                    │
          ┌─────────┴─────────┐
          ▼                   ▼
    Event Handler 1     Event Handler 2
          │                   │
          ▼                   ▼
       Action              Action
```

A C# event is based on a delegate.

The delegate defines the method signature that subscribers must follow, while the event provides a controlled way for the publisher to notify subscribers.

This project therefore provides practical experience with both concepts together.

---

# 📋 6. Queue — Employee Onboarding

The onboarding process uses:

```csharp
Queue<Employee>
```

A queue follows the:

> **FIFO — First In, First Out**

principle.

Example:

```text
Employee A
Employee B
Employee C

     ↓

    Queue

     ↓

Employee A → Employee B → Employee C
```

The first employee added to the onboarding queue is the first employee processed.

This makes `Queue<T>` a natural choice for an onboarding workflow.

---

# 🕘 7. Stack — Action History

The application uses:

```csharp
Stack<string>
```

to maintain action history.

A stack follows:

> **LIFO — Last In, First Out**

principle.

Example:

```text
Action 1
Action 2
Action 3
   ↑
Latest Action
```

When the history is displayed, the most recent action can be accessed first.

---

# 🧩 8. HashSet — Employee Skills

Employee skills are stored using:

```csharp
HashSet<string>
```

The main benefit is that a `HashSet` stores **unique values**.

For example:

```text
C#
SQL
LINQ
C#
```

The duplicate `C#` skill is not stored twice.

```text
HashSet<string>

C#
SQL
LINQ
```

This is a practical example of choosing a collection based on the application's requirements.

---

# 🔍 9. Filtering Employees

The application includes:

```text
14- Filter Employees
```

Filtering allows employee data to be selected according to specific conditions.

This feature demonstrates how collections and reusable logic can work together to retrieve the required employees.

---

# 📈 10. Reports

The project provides reporting functionality such as:

### Average Salary

```text
Employees
    │
    ▼
Salary Values
    │
    ▼
Calculation
    │
    ▼
Average Salary
```

### Department Report

```text
Department
     │
     ▼
Employees
     │
     ▼
Employee Information
     │
     ▼
Department Report
```

These features provide practical examples of processing data stored in collections.

---

# 🏗️ Project Structure

The project is organized into separate folders according to responsibility.

```text
EmployeeManagementSystem
│
├── EmployeeManagementSystem
│   │
│   ├── Common
│   │   └── Result.cs
│   │
│   ├── Events
│   │   └── EmployeeEventArgs.cs
│   │
│   ├── Models
│   │   ├── Employee.cs
│   │   ├── Department.cs
│   │   └── Manager.cs
│   │
│   ├── Services
│   │   └── Company.cs
│   │
│   ├── Program.cs
│   ├── EmployeeManagementSystem.csproj
│   └── EmployeeManagementSystem.sln
│
├── .gitignore
└── README.md
```

---

# 🧩 Project Structure Explained

### `Models/`

Contains the main entities used by the application.

```text
Employee.cs
Department.cs
Manager.cs
```

These classes represent the application's domain objects.

---

### `Services/`

Contains the main application/business logic.

```text
Company.cs
```

The `Company` class coordinates many of the employee and department operations.

---

### `Events/`

Contains event-related functionality.

```text
EmployeeEventArgs.cs
```

This provides custom event data for employee-related events.

---

### `Common/`

Contains shared functionality used by the application.

```text
Result.cs
```

---

### `Program.cs`

The application's entry point.

It handles the console interface and allows the user to select operations from the main menu.

---

# 🔄 Application Architecture

The general relationship between the main parts of the application can be visualized as:

```text
                    ┌──────────────────┐
                    │     Program      │
                    │   Console Menu   │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │     Company      │
                    │  Business Logic  │
                    └────────┬─────────┘
                             │
             ┌───────────────┼───────────────┐
             │               │               │
             ▼               ▼               ▼
        ┌─────────┐     ┌────────────┐   ┌───────────┐
        │Employee │     │ Department │   │  Manager  │
        └─────────┘     └────────────┘   └───────────┘
             │
             ▼
       ┌──────────────┐
       │ Collections  │
       └──────┬───────┘
              │
      ┌───────┼────────┬────────┬────────┐
      ▼       ▼        ▼        ▼        ▼
     List  Dictionary Queue    Stack   HashSet
              │
              ▼
          Application
            Logic
              │
              ▼
          Events / Delegates
```

---

# 🔄 Main Workflow

A typical employee workflow can look like:

```text
Add Employee
     │
     ▼
Employee Added
     │
     ▼
Process Onboarding
     │
     ▼
Employee Ready
     │
     ├───────────────┐
     ▼               ▼
Search           Record Skill
     │               │
     ▼               ▼
Filter          Show Skills
     │
     ▼
Promote Employee
     │
     ▼
Action Recorded
     │
     ▼
Show Action History
```

---

# 🛠️ Technology Stack

### Programming Language

**C#**

### Platform

**.NET Console Application**

### Concepts

* Object-Oriented Programming
* Encapsulation
* Collections
* Generics
* Delegates
* Events
* Custom EventArgs
* Queue / Stack
* Searching
* Filtering
* Data Processing

### Tools

* Visual Studio
* .NET SDK
* Git
* GitHub

---

# 🚀 Getting Started

## Prerequisites

Make sure you have:

* .NET SDK
* Visual Studio 2022 or another compatible C# IDE
* Git

---

## 1️⃣ Clone the Repository

```bash
git clone https://github.com/MohamedElsayed03/EmployeeManagementSystem.git
```

---

## 2️⃣ Navigate to the Project

```bash
cd EmployeeManagementSystem
```

---

## 3️⃣ Open the Solution

Open:

```text
EmployeeManagementSystem.sln
```

using Visual Studio.

---

## 4️⃣ Build the Project

In Visual Studio:

```text
Build
   ↓
Build Solution
```

or press:

```text
Ctrl + Shift + B
```

---

## 5️⃣ Run the Application

Run using:

```text
F5
```

or:

```text
Ctrl + F5
```

---

# 💾 Data Storage

The current version of the project uses **in-memory data**.

No external database is required.

This allows the project to focus on:

```text
C#
 │
 ├── OOP
 ├── Collections
 ├── Generics
 ├── Delegates
 ├── Events
 └── Application Logic
```

---

# 🎓 Learning Outcomes

Building this project helped strengthen practical understanding of:

* Designing classes using OOP
* Modeling real-world entities
* Choosing the correct collection for a problem
* Working with generic collections
* Understanding `Dictionary<TKey, TValue>`
* Using `Queue<T>` for FIFO processing
* Using `Stack<T>` for LIFO history
* Using `HashSet<T>` for unique values
* Creating and using Delegates
* Understanding how Events work with Delegates
* Creating custom `EventArgs`
* Implementing employee filtering
* Building reports from application data
* Organizing code into Models, Services, Events, and Common
* Separating application responsibilities
* Building a complete console application from scratch

---

# 🔮 Future Improvements

The current version focuses on C# fundamentals and application logic.

Possible future improvements include:

* [ ] Add LINQ-based searching and reporting
* [ ] Add SQL Server database integration
* [ ] Add Entity Framework Core
* [ ] Add ASP.NET Core Web API
* [ ] Add authentication and authorization
* [ ] Add a web interface
* [ ] Add dependency injection
* [ ] Add unit testing
* [ ] Add logging
* [ ] Add persistent data storage
* [ ] Convert the project into a complete backend application

---

# 🎯 Project Goal

The main goal of this project was to move beyond learning C# concepts individually and apply them together in one practical application.

Instead of learning:

```text
OOP
Collections
Generics
Delegates
Events
```

as separate topics, this project combines them:

```text
                    Employee Management System
                              │
        ┌─────────────────────┼─────────────────────┐
        │                     │                     │
       OOP               Collections            Generics
        │                     │                     │
        └─────────────────────┼─────────────────────┘
                              │
                         Delegates
                              │
                           Events
                              │
                              ▼
                    Practical C# Application
```

This approach helped turn theoretical C# concepts into practical programming experience.

---

# 👨‍💻 Author

## Mohamed Elsayed

**C# / .NET Developer in Progress**

Interested in:

* C#
* .NET
* ASP.NET Core
* Backend Development
* Software Engineering

---

# ⭐ Support

If you find this project useful or interesting, feel free to explore the source code and give the repository a ⭐.

Feedback and suggestions are always welcome.

---

<div align="center">

### Built with ❤️ using C# and .NET

**Employee Management System**

[View Repository](https://github.com/MohamedElsayed03/EmployeeManagementSystem)

</div>
