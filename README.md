# Best Library Management System

A web-based library management system built with ASP.NET Core MVC that helps libraries manage their books, authors, customers, and library branches.

## Features

- Book management (add, view books)
- Author tracking
- Customer management
- Library branch management
- Book borrowing system
- Multi-platform authentication (Google, Microsoft, Facebook)

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQLite Database
- Bootstrap for UI
- OAuth 2.0 Authentication

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

## Authentication Setup

The application supports multiple OAuth providers. To configure them, update the `appsettings.json` file with your credentials:

### Google Authentication
1. Go to [Google Cloud Console](https://console.cloud.google.com/)
2. Create a new project or select an existing one
3. Configure OAuth 2.0 Client ID
4. Add the ClientId and ClientSecret to appsettings.json

### Microsoft Authentication
1. Go to [Microsoft Azure Portal](https://portal.azure.com/)
2. Register a new application
3. Configure redirect URIs
4. Add the ClientId and ClientSecret to appsettings.json

### Facebook Authentication
1. Go to [Facebook Developers](https://developers.facebook.com/)
2. Create a new app
3. Configure Facebook Login
4. Add the AppId and AppSecret to appsettings.json
