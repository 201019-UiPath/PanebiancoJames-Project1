# GameKingdom Store Application
## Project Description
The purpose of this application is to make shopping for videogames online easier. Customers are able to sign up or log in and begin placing orders at various locations. They also have the option to view their order history. Managers have the ability to check the stock of their given location and replenish it, view location order history, and add a new item.

## Technologies Used
- C#
- PostgreSQL
- HTML5
- CSS3
- JavaScript
- Bootstrap
- EntityFramework Core
- ASP.NET Core
- Serilog
- xUnit

## Features
- User can sign up for account or log in to an existing account
- User can select different store locations and view inventory for each location
- User can view product details, including remaining stock
- User can order multiple products at once
- User can view order history and organize by date or cost
- Manager can add to store location inventory
- Manager can add new products to store locations
- Manager can view order history for a location and organize by date or cost

## Getting Started
To Clone: `git clone https://github.com/201019-UiPath/PanebiancoJames-Project1.git`

- Make sure you have an **appsettings.json** file within the GameKingdomAPI folder which should contain a JSON object called **ConnectionStrings**. From there, create a connection string with all of the relevant database information and credentials with the name **GameKingdomDB**.
1. Have a data access library project separate from the startup application project.
    - With a project reference from the latter to the former.
2. Install **Microsoft Entity Framework Core Design** and **PostgreSQL** to both projects.
3. Run the scaffold code
    - `Dotnet ef dbcontext scaffold -c <connection-string-in-quotes> Npgsql.EntityFrameworkCore.PostgreSQL --startup-project <path to project folder> --force --output-dir Entities`
4. Edit the DBContext.OnConfiguring method from scaffolded code.
5. Any time you change the structure of the tables, go to step 3.

## Usage
- The GameKingdomAPI must be be running on a server in order for the web client application to access the database.
- To run this project from Microsoft Visual Studio, follow these steps:
    - Open the GameKingdomAPI.sln in VS and select Start Without Debugging from the Debug menu. This should start running the GameKingdomAPI from a live server.
    - Open the GameKingdomUI.sln in VS and select Start Without Debugging from the Debug menu. This will start the web client application.
- From the web client application, you can use the web interface to manage user accounts, view inventory, place orders, and so on.

## License
This project uses the following license: [MIT License](LICENSE).