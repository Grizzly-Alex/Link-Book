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
    - [x] [appsettings config](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/appsettings.Development.json)
    - [x] [database context](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/AppDbContext.cs)
    - [x] [extension method AddAppDb](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Configurations/ConfigureDb.cs)
    - [x] [apply](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Program.cs)
      
  + Use fluent API to configure a model
     - [x] [entities of database](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Core/Entities)
     - [x] [fluent configurations](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/Configurations)
     - [x] [apply](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/AppDbContext.cs)
  
  + Using migrations
     - [x] [migration files](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/Migrations)
     - [x] [initializing database](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Data/Initializer.cs)
     - [x] [extension method ApplyMigrations](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Configurations/ConfigureDb.cs)
     - [x] [apply](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Program.cs)

* CRUD operations with using ORM EF Core
  - [x] [repositories](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Repositories)
  - [x] [some queries](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Infrastructure/Queries)

* Mapping
  - [x] [mapping profile](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.Application/Utilities/MappingProfile.cs)
  - [x] [registration profile in DI](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Configurations/ConfigureServices.cs)
 
* CQRS
  - [x] [commands](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Application/Commands)
  - [x] [queries](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Application/Queries)
  - [x] [handlers](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Application/Handlers)

* Using MediatR
  - [x] [registration MediatR in DI](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Configurations/ConfigureServices.cs)
  - [x] [using MediatR in AliasLinkController](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Controllers/AliasLinkController.cs)
  - [x] [using MediatR in AliasCategoryController](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Controllers/AliasCategoryController.cs)

* Application's Responses
  - [x] [responses](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.Application/Responses)

* Handling errors on the server
  - [x] [realization ExceptionHandler](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Utilities/ExceptionHandler.cs)
  - [x] [using in middleware](https://github.com/Grizzly-Alex/Link-Book/blob/feature/clean_architecture/src/Services/Link/Link.API/Program.cs)

* RESTful
  - [x] [Controllers](https://github.com/Grizzly-Alex/Link-Book/tree/feature/clean_architecture/src/Services/Link/Link.API/Controllers)





