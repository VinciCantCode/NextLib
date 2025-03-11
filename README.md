# Best Library Management System

A web-based library management system built with ASP.NET Core MVC that helps libraries manage their books, authors, customers, and library branches.

## Features

- Book management (add, view books)
- Author tracking
- Customer management
- Library branch management
- Book borrowing system

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQLite Database
- Bootstrap for UI

## Getting Started

1. Clone the repository
```bash
git clone https://github.com/VinciCantCode/BestLibraryManagement.git 
cd BestLibraryManagement
```

2. Install required packages
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite  

```
3. Setting Up Entity Framework Core Tools and Creating Initial Migration
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
```

4. Update database
```bash
dotnet ef database update
```

5. Run the application
```bash
dotnet run
```

The application will be available at `https://localhost:5252`

## Project Structure

- `Controllers/`: Contains all MVC controllers
- `Models/`: Data models
- `Views/`: MVC views
- `Data/`: Database context and configurations
- `ViewModels/`: View-specific models
- `wwwroot/`: Static files (CSS, JavaScript, etc.)
