# Error 404 not lost

TODO: Add application description, functionality, usage/contribution instructions, authors.

## Default admin user

The application need an admin user to manage the application.
The default admin user credentials are defined with environnement variables :
- Email: `AdminSettingsEmail`
- Password: `AdminSettingsPassword`

The admin user has the `admin` role that allows him to manage the application, users, and content.

In `the docker-compose.yml` file the variables are already set but :
- **Make sure to change these credentials after the first login for security purposes.**
- **Make sure to use secrets in production environment. (Docker or dotnet secrets)**

## Migration

You can copy this command, make sure you have dotnet 8 installed with entity framework core tools.
```bash
dotnet ef database update --project .\Error404NotLost_DAL\ --startup-project .\Error404NotLost_WEBASP\ --no-build --connection "Server=localhost;Database=Error404NotLost;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
```

Then update the database with:
```bash
dotnet ef database update --project .\Error404NotLost_DAL\ --startup-project .\Error404NotLost_WEBASP\ --no-build --connection "Server=localhost;Database=Error404NotLost;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
```

## Build
You can build the project with the following command:
```bash
dotnet build .\Error404NotLost_WEBASP\Error404NotLost_WEBASP.csproj
```

## Authors

[Namulabre](https://github.com/Namularbre)

**Other authors need to be added here.**
