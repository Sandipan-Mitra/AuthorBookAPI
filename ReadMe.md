AuthorBook API
Overview
This is a simple ASP.NET Core 8 Web API project for managing authors and books. The API allows CRUD operations (Create, Read, Update, Delete) for two entities: Author and Book. It follows REST principles, uses Entity Framework Core for data persistence with SQL Server, and includes validation, error handling, and clean architecture.

Prerequisites
.NET SDK 8 installed. Download here
SQL Server installed and running. (You can use SQL Express, LocalDB, or a full SQL Server instance)
Visual Studio 2022 (or later) for development (optional but recommended).
Project Setup
1.Upzip the Solution.
2. Configure the Database
Make sure SQL Server is running, and update the connection string in appsettings.json if needed:

json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AuthorBookDb;Trusted_Connection=True;Encrypt=False;"
  }
}
If you're using a different SQL Server instance, replace the connection string accordingly.

3.Apply Database Migrations
Before running the application, apply the initial database migration to set up the schema.
update-database
This will create the AuthorBookDb database and set up the Authors and Books tables.

5. Run the Application
You can run the application via the command line or in Visual Studio:

In Visual Studio:
Open the solution in Visual Studio.
Press F5 to run the application.
Once the application is running, the API will be available at https://localhost:5001 (or another port if configured).

6. API Documentation
Swagger is integrated for API documentation. You can access it at:


https://localhost:5001/swagger
Swagger provides a visual interface to test all API endpoints.

API Endpoints
Author Endpoints
GET /api/authors: Retrieve all authors.
GET /api/authors/{id}: Retrieve an author by ID.
POST /api/authors: Create a new author.
Request body:
json
{
  "name": "Author Name",
  "email": "author@example.com"
}
PUT /api/authors/{id}: Update an existing author.
Request body:
json
{
  "name": "Updated Name",
  "email": "updated@example.com"
}
PATCH /api/authors/{id}: Partially update an existing author.
Request body (only fields to update):
json
{
  "email": "updated@example.com"
}
DELETE /api/authors/{id}: Delete an author by ID.
Book Endpoints
GET /api/books: Retrieve all books.
GET /api/books/{id}: Retrieve a book by ID.
POST /api/books: Create a new book.
Request body:
json
{
  "title": "Book Title",
  "isbn": "1234567890123",
  "authorId": 1
}
PUT /api/books/{id}: Update an existing book.
Request body:
json
{
  "title": "Updated Title",
  "isbn": "9876543210987",
  "authorId": 1
}
PATCH /api/books/{id}: Partially update an existing book.
Request body (only fields to update):
json
{
  "title": "Updated Title"
}
DELETE /api/books/{id}: Delete a book by ID.



Database Configuration
The project uses Entity Framework Core with SQL Server as the database provider. You can configure the database connection string in the appsettings.json file under the "ConnectionStrings" section.

Changing Database Provider
If you want to switch to a different database like PostgreSQL or MySQL, follow these steps:

Install the relevant EF Core provider NuGet package (e.g., Npgsql.EntityFrameworkCore.PostgreSQL for PostgreSQL).
Update AppDbContext in the Program.cs file to use the appropriate database provider.
csharp

// For PostgreSQL:
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
Update the connection string in appsettings.json accordingly.
Code Structure
Models: Contains the entity models Author and Book.
DTOs: Data Transfer Objects to decouple API request/response models from the database models.
Interfaces: Contains interfaces for the repository layer.
Repositories: Contains repository implementations for data access (using Entity Framework Core).
Controllers: API controllers exposing the endpoints for Author and Book.
Data: Contains AppDbContext for managing database connections and models.
