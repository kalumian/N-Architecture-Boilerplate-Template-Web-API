# N-Architecture Template Web API

A starter boilerplate for .NET 8 Web API projects following an N-Layered architecture to ensure separation of concerns, scalability, and maintainability.

---

## 📖 Overview

This template demonstrates a clean, modular architecture with the following layers:

- **Presenter** (Web API): Entry point, controllers, middleware, and API configuration.
- **Service**: Business logic and background services.
- **Validation**: Input validation using FluentValidation.
- **DataAccess**: Entity Framework Core DbContext, repositories, and Unit of Work.
- **Model**: Entities, DTOs, enums, interfaces, and shared mappings.
- **Core**: (Optional) Common interfaces, result wrappers, and shared utilities.

Each layer is implemented as a separate .NET project with explicit project references, making it easy to plug into new solutions.

---

## 📂 Project Structure

```plaintext
N-Architecture.Template/
├── Presenter_Layer/           # ASP.NET Core Web API
├── Service_Layer/             # Business services & background jobs
├── Validation_Layer/          # FluentValidation rules
├── DataAccess/                # EF Core DbContext, repositories, migrations
├── Model_Layer/               # DTOs, Entities, Enums, Interfaces
└── N-Architecture.Template.sln # Solution file
```

---

## 🔗 Project References & SDKs

### Model Layer (`Model-Layer.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>Model_Layer</RootNamespace>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <Folder Include="Entities\" />
    <Folder Include="Interfaces\" />
    <Folder Include="Enums\" />
    <Folder Include="DTOs\" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="AutoMapper" Version="14.0.0" />
  </ItemGroup>
</Project>
```

### Data Access Layer (`Data-Access-Layer.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\Model-Layer\Model-Layer.csproj" />
  </ItemGroup>
</Project>
```

### Validation Layer (`Validation-Layer.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>Validation_Layer</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\DataAccess\Data-Access-Layer.csproj" />
    <ProjectReference Include="..\Model-Layer\Model-Layer.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />
  </ItemGroup>
</Project>
```

### Service Layer (`Service-Layer.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>Service_Layer</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\DataAccess\Data-Access-Layer.csproj" />
    <ProjectReference Include="..\Model-Layer\Model-Layer.csproj" />
    <ProjectReference Include="..\Validation-Layer\Validation-Layer.csproj" />
  </ItemGroup>
</Project>
```

### Presenter Layer (`Presenter_Layer.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>Presenter_Layer</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="AutoMapper" Version="14.0.0" />
    <PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.4" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\DataAccess\Data-Access-Layer.csproj" />
    <ProjectReference Include="..\Model-Layer\Model-Layer.csproj" />
    <ProjectReference Include="..\Service-Layer\Service-Layer.csproj" />
    <ProjectReference Include="..\Validation-Layer\Validation-Layer.csproj" />
  </ItemGroup>
</Project>
```

---

## ⚙️ Dependencies & NuGet Packages

- **AutoMapper** (v14.0.0) – Object-to-object mapping.
- **FluentValidation.AspNetCore** (v11.3.0) – Model validation.
- **Microsoft.EntityFrameworkCore** (v8.0.0 / 9.0.4) – ORM core.
- **Microsoft.EntityFrameworkCore.SqlServer** (v9.0.4) – SQL Server provider.
- **Swashbuckle.AspNetCore** (v6.6.2) – Swagger API documentation.

Additional essentials:
- `Microsoft.Extensions.DependencyInjection`
- `Microsoft.EntityFrameworkCore.Tools`

---

## 🚀 Getting Started

1. **Clone the repo**:
   ```bash
   git clone https://github.com/your-repo/N-Architecture.Template.git
   ```
2. **Set your connection string** in `appsettings.json` under `Presenter_Layer` project:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=MyDb;Trusted_Connection=True;"
   }
   ```
3. **Restore packages** and **run migrations**:
   ```bash
   cd Presenter_Layer
   dotnet restore
   dotnet ef database update
   ```
4. **Run the API**:
   ```bash
   dotnet run
   ```
5. **Explore** using Swagger UI at `https://localhost:{port}/swagger`.

---

## 🧩 Extending the Template

- **Add new layers** (e.g., `Integration`, `Infrastructure`).
- **Integrate SignalR/WebSockets**.
- **Implement authentication/authorization** (JWT, IdentityServer).
- **Customize error handling** with middleware.

---

## 📝 License

This project is licensed under the MIT License. Feel free to use and adapt it for your own needs.
