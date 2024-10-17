# Link-Book (Application for saving your favorite URL-links)

## Developing Link Service (API Clean Architectire)
### Layers of architecture:
- API
- Application
- Infrastructure
- Core

### Using libruares:
* AutoMapper
* AutoMapper.Extensions.Microsoft.DependencyInjection
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* MediatR

### Implementations:
* Database
  + Using EF Core ORM for connect to a relational database
    - [appsettings config](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/appsettings.Development.json)
    - [database context](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/AppDbContext.cs)
    - [extension method AddAppDb](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Configurations/ConfigureDb.cs)
    - [apply](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Program.cs)
      
  + Use fluent API to configure a model
     - [entities of database](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Core/Entities)
     - [fluent configurations](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/Configurations)
     - [apply](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/AppDbContext.cs)
  
  + Using migrations
     - [migration files](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/Migrations)
     - [initializing database](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/Initializer.cs)
     - [extension method ApplyMigrations](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Configurations/ConfigureDb.cs)
     - [apply](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Program.cs)




