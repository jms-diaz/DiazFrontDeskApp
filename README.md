# DiazFrontDeskApp
Coding exercise for Stealth Monitoring

The Front Desk Application is a web-based application designed to manage packages in a front desk setting. It allows users to add, retrieve, and track packages within different package areas. The application is built using ASP.NET MVC and utilizes SQL Server to store package and package area information.

## Getting Started

### Prerequisites

- Visual Studio (2019 or later) with ASP.NET MVC support.
- .NET Framework (minimum version required).

### Installation

1. Clone the repository to your local machine:

```bash
git clone https://github.com/your-username/front-desk-app.git
```

2. Open the solution file (FrontDeskApp.sln) in Visual Studio.

3. Restore NuGet packages: Right-click on the solution in Solution Explorer, and select "Restore NuGet Packages" to install the required packages.

4. Set up the database: Update the connection string in the "Web.config" file to point to your database. Then, run the database migrations to create the required tables:

```bash
Update-Database
```

5. Build and run the application: Press `Ctrl + F5` to build and run the application. The application will be accessible at `http://localhost:port/` (replace "port" with the appropriate port number).

## Features

- **Package Management**: Users can add new packages and track their status.
- **Package Area Management**: Users can define and manage different package areas with their maximum capacity.
- **Package Retrieval**: Packages can be marked as retrieved with the date and time of retrieval recorded.
- **Capacity Check**: Before adding a package, the application checks if the package area has enough capacity to accept the package.

## Application Structure

The application follows the standard ASP.NET MVC structure:

- `Controllers`: Contains the controller classes that handle user requests and data processing.
- `Models`: Contains the model classes representing the entities in the application (e.g., Package, PackageArea).
- `Views`: Contains the Razor views for the user interface.
- `Interfaces`: Contains the interfaces that define contracts for various services in the application.
- `Repositories`: Contains the repository classes that implement the interfaces for data access and encapsulate database operations.
- `Data`: Contains the data context class and database migrations.
- `Scripts`: Contains JavaScript files used in the views.
- `Content`: Contains CSS files and other static resources.

## Usage

1. **Home Page**: The home page displays information about the package areas.

2. **Package**: Click on "Package" to retrieve all the packages and to add a new package. Select the package area, provide package details, and save the package.

3. **User**: Click on "User" to retrieve all users and to add a new user. Fill out the user details, and save the user.

4. **Edit Package**: Click on "Edit" on a package row to update its status. The retrieval date will be automatically updated to the current date.

## Troubleshooting

- If there are any issues related to the database or migrations, check the connection string and ensure that the database server is running.
- Verify that the required NuGet packages are installed and up-to-date.
