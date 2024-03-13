# User Management application
This user management application using Blazor Web Assembly leverages a three-tier architecture consisting of API, frontend application, and data layers. It was connected to a PostgreSQL database hosted on AWS RDS which serves as the persistent data store.
<br><br>
<img width="1438" alt="app" src="https://github.com/Doris-Siu/UserManagement_Client/assets/107772913/e5d86d27-fcce-4e7c-a2bc-c62c83848c63">
<br><br>
The front-end application consumes API to perform CRUD operations.
<br><br>
<img width="1437" alt="api" src="https://github.com/Doris-Siu/UserManagement_Client/assets/107772913/76304360-8d31-409c-ae78-21fe4647dcdb">
<br><br>
PostgreSQL database serves as the persistent data store. Interacts with the database is facilitated through Entity Framework.

<img width="1383" alt="Screenshot 2024-03-13 at 12 14 56 AM" src="https://github.com/Doris-Siu/UserManagement_Client/assets/107772913/be6b3004-f897-4f46-8efe-1a7648a63e46">
<br><br>

## Technologies
- BlazorWASM
- C#
- .NET7
- API
- EF
- PostgreSQL
- Blazor Bootstrap
<br><br>
## Features
✅ Filters Section - all 3 working buttons<br>
✅ User Model Properties - DateOfBirth property added<br>
✅ Actions Section - Add, View, Edit, and Delete working pages with validation<br>
✅ Data Logging - a list of all actions including login, logout, and CRUD operations performed by the user<br>
✅ Make a significant architectural change - three-tier architecture promoting separation of concern<br>
✅ Connecting to an API - Use of Blazor<br>
✅ Support asynchronous operations<br>
✅ Implement authentication and login based on the users being stored<br>
✅ Implement bundling of static assets - dotnet publish -c Release<br>
✅ Use a real database, implement database schema migrations - PostsgreSQL, EF used<br>
<br><br>
## Opening in Visual Studio
Prerequisites:
- Follow the steps [here](https://github.com/dotnet/aspnetcore/blob/main/docs/BuildFromSource.md) to set up a local copy of dotnet
- Visual Studio 2017 15.7 latest preview - [download](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?ch=pre&sku=Enterprise&rel=15)

We recommend getting the latest preview version of Visual Studio and updating it frequently. The Blazor editing experience in Visual Studio depends on new features of the Razor language tooling and will be updated frequently.

When installing Visual Studio choose the following workloads:

- ASP.NET and Web Development
- Visual Studio extension development features

If you have problems using Visual Studio with Blazor.sln please refer to the [developer documentation](https://github.com/dotnet/aspnetcore/blob/main/docs/BuildFromSource.md).
<br><br>

## License
This project is licensed under the [MIT](https://choosealicense.com/licenses/mit/)


