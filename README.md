# ContactManagement POC

This project is an example of contact management with add/edit/delete functionality using new technologies and best practices.

The goal is to create POC using new technologies like angular, dot net core,serilog,swagger.

Thanks for enjoying!

## Build


## Code Analysis


## Technologies

* [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)
* [Entity Framework Core 2.1](https://docs.microsoft.com/en-us/ef/core)
* [C# 8.0](https://docs.microsoft.com/en-us/dotnet/csharp)
* [Angular 8.3](https://angular.io/docs)
* [Typescript 3.5.3](https://www.typescriptlang.org/docs/home.html)
* [HTML](https://www.w3schools.com/html)
* [CSS](https://www.w3schools.com/css)
* [SASS](https://sass-lang.com)
* [swagger 4.0.1]
*[serilog](https://serilog.net/))

## Practices

* Clean Code
* SOLID Principles
* DDD (Domain-Driven Design)
* Code Analysis
* Inversion of Control
* Dependancy injection
* Database Migrations



## Run

<details>
<summary>Command Line</summary>

#### Prerequisites

* [.NET Core SDK](https://aka.ms/dotnet-download)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=853016)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps
1.Open directory **source\SqlScript in sql server management studi and run it by pressing F5
2. Open directory **source\Front_End\contactMangementUI\src\environments\environment.ts**.change api url with your url.
3.Open directory **source\Front_End\contactMangementUI** in command line and execute **npm run install**.
4. open directory **ContactManagement\ContactManagement.API\appsettings.json** change database connection string with your connection string.
5. Open directory **source\ContactManagement\ContactManagement.API** in command line and execute **dotnet run**.
6. Need to create and install sel ssl certificate to access api over https.

</details>

<details>
<summary>Visual Studio</summary>

#### Prerequisites

* [.NET Core SDK](https://aka.ms/dotnet-download)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=853016)
* [Visual Studio 2017](https://visualstudio.microsoft.com/vs/older-downloads/)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1.Open directory **source\SqlScript in sql server management studi and run it by pressing F5
2. Open directory **source\Front_End\contactMangementUI\src\environments\environment.ts**.change api url with your url.
3.Open directory **source\Front_End\contactMangementUI** in command line and execute **npm run install**.
4. open directory **ContactManagement\ContactManagement.API\appsettings.json** change database connection string with your connection string.
5. Open **source\ContactManagement\ContactManagement** directory in Visual Studio 2017..
6. Press **F5**.

</details>


<details>
<summary>Tools</summary>

* [Visual Studio](https://visualstudio.microsoft.com)
* [Visual Studio Code](https://code.visualstudio.com)
* [SQL Server](https://www.microsoft.com/sql-server)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)
* [Postman](https://www.getpostman.com)


</details>
<details>
<summary>Project structure</summary>

* We have consolidate one soln contact management. It contain 4 diffrent project/ class libraries.
  1) ContactManagement.API :- This is main restful api project. It contain required controller and related filter/configuration logic. This project have refrence of business layer to get required data. We implemented dependancy injection to create loosely coupled architecture.
  2) ContactManagement.BusinessManager :- This contain business logic related to project.This called data access layer to fetch data from database.
  3) ContactManagement.Repository :- We have used entity framework to fetch data from database. We stored data into sql server.This project fetch data from database and passed to business layer.
  4)ContactMangement.Logger :- This project is centralise logging system for our project. We have used serilog to log error messages and info message in database as well as in file.
</details>



