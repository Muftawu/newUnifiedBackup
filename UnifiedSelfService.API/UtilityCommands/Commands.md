### Scaffolding the database

dotnet ef dbcontext scaffold "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -o ../Domain/Models/ --context-dir ../Infrastructure/Data/ --context ApplicationDbContext --startup-project Presentation.csproj --force

### Database Makemigrations
dotnet ef migrations add InitialCreate --project . --startup-project ../Presentation/Presentation.csproj

### Database Migrate
dotnet ef database update --project . --startup-project ../Presentation/Presentation.csproj 

### MSSQL connection string
"DefaultConnection" : "Server=192.168.0.181,1433;Database=USS_DB;User Id=unifiedsystemsquad;Password=UniXSquad@2025;TrustServerCertificate=True"

### local mssql server 
"DefaultConnection" : "Server=localhost,1433;Database=appdb;User Id=SA;Password=Muftawu@2024;TrustServerCertificate=True"


### Test English Department Admin Credentials
estelladoku1@knust.edu.gh
