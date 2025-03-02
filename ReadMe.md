

# Kommentarer

Jeg velger å bruke flertall og ikke entall når det gjelder Note og Folder. 


For å installere Serilog må man kjøre:

dotnet add package Serilog.AspNetCore

dotnet add package Serilog.Settings.Configuration

dotnet add package Serilog.Sinks.Console

dotnet add package Serilog.Sinks.File


For å installere sqlite må man kjøre:

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet add package Microsoft.EntityFrameworkCore.Tools


For å installerre migrations må man kjøre:

dotnet tool install --global dotnet-ef


For å installere DbContext må man kjøre:

dotnet add package Microsoft.EntityFrameworkCore


Migrations:

dotnet ef database update

dotnet ef migrations add InitialCreate <--kjør denne når det går an å kjøre build