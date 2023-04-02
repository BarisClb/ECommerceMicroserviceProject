FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/ProductService/ProductService.WebAPI/ProductService.WebAPI.csproj", "Services/ProductService/ProductService.WebAPI/"]
COPY ["Shared/SharedLibrary/SharedLibrary.csproj", "Shared/SharedLibrary/"]
COPY ["Services/ProductService/ProductService.Application/ProductService.Application.csproj", "Services/ProductService/ProductService.Application/"]
COPY ["Services/ProductService/ProductService.Domain/ProductService.Domain.csproj", "Services/ProductService/ProductService.Domain/"]
COPY ["Services/ProductService/ProductService.Infrastructure/ProductService.Infrastructure.csproj", "Services/ProductService/ProductService.Infrastructure/"]
COPY ["Services/ProductService/ProductService.Persistence/ProductService.Persistence.csproj", "Services/ProductService/ProductService.Persistence/"]
RUN dotnet restore "Services/ProductService/ProductService.WebAPI/ProductService.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/ProductService/ProductService.WebAPI"
RUN dotnet build "ProductService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.WebAPI.dll"]