⚙️ Entity Framework Core Migration Commands
Run the following commands to create and apply initial migrations for both microservices:

✅ ProductService
1. dotnet ef migrations add Init -p ProductService -s ProductService
2. dotnet ef database update -p ProductService -s ProductService

✅ CartService
1. dotnet ef migrations add Init -p CartService -s CartService
2. dotnet ef database update -p CartService -s CartService
