## Preinscription

# Dependencies for database
Launch inside project
```bash
    dotnet tool install --global dotnet-ef

    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
    dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Edit file "appsetings.json"
add
```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Host=localhost;Database=<database name>;Username=<database user>;Password=<password>"
        }
    }
```

Launch (if use db first)
```bash
    dotnet ef dbcontext scaffold "Host=localhost;Database=ma_base;Username=postgres;Password=mot_de_passe" Npgsql.EntityFrameworkCore.PostgreSQL -o Models
```