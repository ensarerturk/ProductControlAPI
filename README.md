# Product Management API
This project includes an ASP.NET Core Web API application focused on product management. The API can perform basic operations such as listing, adding, updating, deleting products. It also has additional features such as filtering products by name, filtering by type, filtering by name and sorting.

## Technologies Used
- ASP.NET Core 5
- Entity Framework Core
- Swagger: Used for API documentation.
- JWT: Used for user login and token management.

## Dependencies and Setup
The project uses the PostgreSQL database. You can edit the database connection information in the `appsettings.json` file in the project directory.


To run the API, you can type the following command in the terminal:

```bash
dotnet run
```
You can use the Swagger documentation for more information. Once the API is running, you can access the API documentation by going to `https://localhost:5001/swagger` from your browser.


## Project Structure
- **Controllers:** The controller classes that handle API endpoints are located here.

- - **ProductManagementController:** Performs basic CRUD operations.
- - **ProductFilterController:** Filters products by name.
- - **ProductSortController:** Sorts products by name and increments prices.
- - **SampleController:** Contains a sample user login system and operations that generate tokens.

- **DBOperations:** Contains classes that manage database operations.

- - **ProductDbContext:** Provides the database connection used by the Entity Framework.
- - **IProductRepository:** Defines the interface for product database operations.
- - **ProductRepository:** Implements IProductRepository, performs the actual database operations.

- **Extensions:** Extension methods are located in this folder.

- - **ProductExtensions:** Contains extension methods specific to the product class.
- - **ProductListExtensions:** Contains extension methods specific to the List<Product> type.

- **Middleware:** Contains ASP.NET Core middleware classes.

- - **GlobalExceptionMiddleware:** Provides global error handling for all requests.
- - **LoggingMiddleware:** Performs logging at the beginning and end of requests.

- **Models:** Contains data models.

- - **Product:** Represents the basic product model.
- - **FakeUser:** Represents the sample user model.
- - **TokenManager:** Provides JWT token management.

- **Services:** Contains business logic services.

- - **AuthenticationService:** Manages user login operations.
- - **IProductService:** Defines the interface for product operations.
- - **ProductService:** Implements IProductService, performs product operations.

- **Test/UnitTests/FakeServices:** Contains fake service classes for test classes.

- - **FakeProductRepository:** Contains the fake product database operations.
- - **FakeProductService:** Implements IProductService, performs fake product operations.

## General Information
- **SOLID Principles:** The project was designed in accordance with SOLID principles.
- **Dependency Injection:** Dependency Injection was used by developing fake services.
- **Swagger Implementation:** Swagger was used for API documentation.
- **Global Logging Middleware:** There is a middleware that performs logging at the beginning and end of each HTTP request.
- **Fake User Login System and Custom Attribute:**  A sample user login system and `FakeAuthorizeAttribute` custom attribute have been added.
- **Global Exception Middleware:** There is a global exception middleware that covers all requests.