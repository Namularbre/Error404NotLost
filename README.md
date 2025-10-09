# Error 404 not lost

TODO: Add application description, functionality, usage/contribution instructions, authors.

## Installation

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [Docker](https://www.docker.com/get-started/) (if using Docker for database)

### Clone the repository
```bash
git clone git@github.com:Namularbre/Error404NotLost.git
```
### Setup
1. Navigate to the project directory:
   ```bash
   cd Error404NotLost
   ```
2. Install nuggets sources and dotnet-ef if needed : 
    ```bash
   dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
    dotnet tool install --global dotnet-ef    
   ```
3. Build project :
    ```bash
    dotnet build .\Error404NotLost_WEBASP\Error404NotLost_WEBASP.csproj    
   ```
4. Set up the database:
    ```bash 
     docker compose up -d
     dotnet ef database update --project .\Error404NotLost_DAL\ --startup-project .\Error404NotLost_WEBASP\ --no-build --connection "Server=localhost;Database=Error404NotLost;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
    ```
5. Restart docker containers
    ```bash
    docker compose restart
    ```
   
## Migration

You can copy this command, make sure you have dotnet 8 installed with entity framework core tools.
```bash
dotnet ef migrations add InitialMigration --project .\Error404NotLost_DAL\ --startup-project .\Error404NotLost_WEBASP\
```

Then update the database with:
```bash
dotnet ef database update --project .\Error404NotLost_DAL\ --startup-project .\Error404NotLost_WEBASP\
```

## Build
You can build the project with the following command:
```bash
dotnet build .\Error404NotLost_WEBASP\Error404NotLost_WEBASP.csproj
```

## Authors

[Namulabre](https://github.com/Namularbre)

**Other authors need to be added here.**
