# Physical Therapy Tool

This is a web application for physical therapy. It allows physical therapist to send their patients a routine electronically vs. the old fashion pen and paper. 
Patients will be able to view the routine, do them, and send feedback to the therapist.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

Things you will need installed and how to install them.

**1.)**		
Microsoft Visual Studio and Visual Studio Code
Both can be found at:
<br>
https://visualstudio.microsoft.com/

**2.)**		
Microsoft SQL Server Management Studio
<br>
https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017

**3.)**		
Postman
<br>
https://www.getpostman.com/

### Installing

Step by Step Installation to set up development environment.

**1.)**	
you will need .NET CORE SDK installed. You can find the latest version here:
<br>
https://docs.microsoft.com/en-us/dotnet/core/

**2.)**		
you will now need to install the latest version of Node.js. You can find the latest version here:
<br>
https://nodejs.org/en/

**3.)**
If you're using GitHub, make sure you have the extension installed on Visual Studio. You can find it under:
<br>
``` Tools -> Extensions and Updates... -> Online -> GitHub Extension for Visual Studio ```

**4.)**
In Visual Studio Code, open the Client folder. This is the front end of the project.
You will first need to install Angular CLI. This can be done in Visual Studio Code's terminal.
Enter the following command:
<br>
``` npm install -g @angular/cli ```

**5.)**
Make sure there is a class called appsettings.json in the project. The content should look like this:
<br>
```
{
  "ConnectionStrings": {
    "Development": "{{Connection_String_Here}}",
    
    
    "Logging": {
      "IncludeScopes": false,
      "LogLevel": {
        "Default": "Warning"
      }
    }
  }
}
```
Replace {{Connection_String_Here}} inide the quotation with your database connection string.

**6.)**
This project is was develop using Code First Migrations with Entity Framework Core
<br>
https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/
<br>
https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
To scaffold the project open up Package Manger Console (under Views -> Other Windows). Since there's already migrations set you'll just have to update the database. But if Migrations directory is not there, enter the following Commands:
<br>
```
dotnet ef migrations add InitialCreate

dotnet ef database update
```
This will create the migrations and update the databse according to the entities and context. Any future changes to database's structure or relationships, the previous two commands will be used again.

**7.)**
in the global.ts class on the front end, uncomment the localhost and comment the azurewebsites.net. This is so that the local development api will be hit instead of production api.

```
//export const apiEndpoint = 'http://localhost:50000/api';
export const apiEndpoint = 'https://webapipt.azurewebsites.net/api';
```
