FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY src/CatalogService.Domain/CatalogService.Domain.csproj ./src/CatalogService.Domain/
COPY src/CatalogService.Application/CatalogService.Application.csproj ./src/CatalogService.Application/
COPY src/CatalogService.Infrastructure/CatalogService.Infrastructure.csproj ./src/CatalogService.Infrastructure/
COPY src/CatalogService.Api/CatalogService.Api.csproj ./src/CatalogService.Api/
RUN dotnet restore ./src/CatalogService.Api/CatalogService.Api.csproj

COPY . ./
RUN dotnet publish ./src/CatalogService.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
EXPOSE 5432
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CatalogService.Api.dll"]
