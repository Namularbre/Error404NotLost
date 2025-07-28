# Error 404 not lost

TODO: Add application description, functionality, usage/contribution instructions, authors.

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
