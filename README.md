# Travel Experts Management System

Windows Forms application for managing travel packages, products, and suppliers using Entity Framework Core and
Microsoft SQL Server.

## Technologies Used

- .NET 8.0 Windows Forms
- Entity Framework Core
- Microsoft SQL Server
- C#

## Database Setup Options

### Option 1: Using Entity Framework Migrations (Recommended for Developers)

1. Copy App.config.example to string in App.config
2. Open Package Manager Console in Visual Studio
3. Run:
   ```powershell
   Update-Database
   ```

### Option 2: Direct SQL Script Import

Open SQL Server Management Studio
Connect to your SQL Server instance
Create new database named 'TravelExperts'
Execute the script from database/travelexperts-mssql.sql

### Development Setup

Clone the repository
Set up database using one of the options above
Copy App.config.example to App.config and update connection string
Build and run in Visual Studio 2022
