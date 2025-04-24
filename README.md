# Best Library Management System

A web-based library management system built with ASP.NET Core MVC that helps libraries manage their books, authors, customers, and library branches.

## Features

- Book management (add, view books)
- Author tracking
- Customer management
- Library branch management
- Book borrowing system
- Multi-platform authentication (Google, Microsoft, Facebook)
- RESTful API for system integration
- Comprehensive error handling
- Interactive API documentation with Swagger UI

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQLite Database
- Bootstrap for UI
- OAuth 2.0 Authentication
- Swagger/OpenAPI for API documentation
- RESTful API endpoints
- Custom error handling middleware

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

## Error Handling

The system implements comprehensive error handling:
- Custom error pages for different HTTP status codes
- User-friendly error messages
- Logging of errors for debugging
- Status code pages with re-execution

## REST API

The system now provides a RESTful API for book management, enabling integration with other systems:

### API Endpoints

#### Books API
- `GET /api/BooksApi` - Retrieve all books
- `GET /api/BooksApi/{title}` - Retrieve a specific book
- `POST /api/BooksApi` - Add a new book
- `PUT /api/BooksApi/{title}` - Update an existing book
- `DELETE /api/BooksApi/{title}` - Delete a book

### API Documentation
- Interactive API documentation is available at `/swagger` in development environment
- Swagger UI for testing API endpoints
- JSON responses for easy integration

### API Usage Example
```bash
# Get all books
curl -X GET https://localhost:5252/api/BooksApi

# Add a new book
curl -X POST https://localhost:5252/api/BooksApi \
  -H "Content-Type: application/json" \
  -d '{
    "title": "New Book",
    "authorName": "Author Name",
    "libraryBranchName": "Main Branch"
  }'
```
