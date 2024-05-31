# ST10203137 - AGRICONNECT Platform

## Overview

AgriConnect is a web-based platform designed to streamline the management of agricultural products and farmer profiles. This project aims to provide a user-friendly interface for both farmers and employees, enabling efficient data entry, management, and retrieval. The system includes robust functionalities for adding and viewing products, creating farmer profiles, and implementing secure user authentication.

## Setup and Installation

### Prerequisites

- Visual Studio 2019 or later
- .NET Core SDK
- SQL Server Management Studio (SSMS) or MySQL Server
- Git

### Steps

1. **Clone the Repository**

   
   git clone https://github.com/thekayd/prog7311-part-2-submission-ST10203137.git
   
 **OR**
   
2. **Clone the Repository**
   Download the zip folder (This may be the better option)

## Set Up the Database

1. Open SQL Server Management Studio (SSMS) or MySQL Workbench.
2. Create a new database named `AgriConnectDatabase`.
3. Run the SQL script located at in the project zip folder to set up the schema and populate the database with sample data.

## Configure Connection String

1. Open `appsettings.json` in the root of the project inside c#.
2. Update the connection string to point to your SQL Server instance or MySQL Server.
 ##  Example:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AgriConnectDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

 ## NuGet Packages to Download in Visual Studio
To ensure all necessary dependencies are installed, download the following NuGet packages using the NuGet Package Manager Console in Visual Studio.

**Microsoft Entity Framework Core**
- Install-Package Microsoft.EntityFrameworkCore

**Microsoft SQL Server**
- Install-Package Microsoft.EntityFrameworkCore.SqlServer
  
**Microsoft Tools**
- Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
- 
**Microsoft Entity Frameworks**
- Install-Package Microsoft.EntityFrameworkCore.Tools

**Microsoft Entity Framework Core Design**
- Install-Package Microsoft.EntityFrameworkCore.Design


## Running the Prototype

### Run the Application

1. In Visual Studio, set AgriConnect as the startup project.
2. Press F5 or click on the 'Run' button to start the application.

### Access the Application

1. Open your browser and navigate to https://localhost:7001 (or the URL given by your development server).

## System Functionalities

### For Farmers

- **Add Products:** Farmers can add new products to their profile by providing details such as name, category, and production date.
- **View Products:** Farmers can view a list of all products they have added.

### For Employees

- **Add Farmer Profiles:** Employees can create new farmer profiles by entering essential details like first name, last name, username, and email.
- **View Products by Farmer:** Employees can view a comprehensive list of products from specific farmers. They can also filter products based on criteria such as date range and product type.

## User Roles

### Farmer

- **Permissions:** Add products, view their own product listings.
- **Authentication:** Secure login to access their profile and manage products.

### Employee

- **Permissions:** Add new farmer profiles, view all products from specific farmers, use filters for product searching.
- **Authentication:** Secure login to access the employee functionalities.

## Database Design

The database is designed to manage information about farmers and their products. Key tables include:

- **Farmers:** Stores information about each farmer (FarmerID, FirstName, LastName, Username, Password, Email).
- **Employees:** Stores information about each Employee (EmployeeID, FirstName, LastName, Username, Password, Email).
- **Products:** Stores information about each product (ProductID, Name, Category, ProductionDate, FarmerID).
  

## Application Usage

Upon running the application, users will encounter a login page. If the login attempt is unsuccessful, they will be prompted with an error message.

### Logging In

Users can sign in as either a farmer or an employee using the dummy data provided in the database script. Depending on the user role, they will be directed to different dashboards upon successful login.

#### Farmer Login

If the user logs in as a farmer:
- They will be directed to the home page where they can view their specific products.
- The navigation bar at the top allows them to navigate between the home page and the "Create Products" page, as well as providing a logout option.
- In the home page, they can view their own products.
- In the "Create Products" page, they can add new products by providing the name, production date, and product type. Clicking the "Add Products" button will redirect them back to the home page to view their products.

#### Employee Login

If the user logs in as an employee:
- They will be directed to the employee dashboard.
- In the home page, they can view all products for the farmers in the database.
- Each farmer's details include a button to view their personal details and specific products.
- The navigation bar provides options to navigate between the home page, create farmer page, view products by farmer page, and logout.
- In the create farmer page, employees can create a new farmer by entering their name, last name, username, and email. They can generate a random password for the user. Clicking the "Create farmer" button stores the farmer in the database and redirects the user back to the home screen.
- In the view products by farmer page, employees can filter through all farmers collectively or individually based on names, start and end dates of production, and product type. This allows for detailed filtering and searching of each farmer's details.
- The logout button allows employees to log out of the system.

All data interactions are managed through the database connection, ensuring that all data is saved and retrieved accurately.



## Development and Testing Process

### Iterative Development

The prototype was developed iteratively, with each functionality being tested thoroughly before moving on to the next. This ensured a robust and bug-free application.

### User Experience (UX) Testing

Sample users were involved in UX testing to provide feedback on the interface and usability. This feedback was used to make necessary adjustments to improve the overall user experience.

### Data Validation and Error Handling

Data validation checks were implemented to maintain the accuracy and consistency of the information entered into the system. Error-handling mechanisms were put in place to prevent system crashes and data corruption.

## Conclusion

The AgriConnect platform is designed to facilitate the efficient management of agricultural products and farmer profiles. By following the setup instructions and understanding the functionalities, users can easily get the prototype up and running. The system's clear and intuitive interface, along with secure authentication mechanisms, ensures a seamless experience for both farmers and employees.

This README file is included in the project package for easy access and guidance.
