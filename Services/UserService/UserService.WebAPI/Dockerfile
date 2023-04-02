FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/UserService/UserService.WebAPI/UserService.WebAPI.csproj", "Services/UserService/UserService.WebAPI/"]
COPY ["Shared/SharedLibrary/SharedLibrary.csproj", "Shared/SharedLibrary/"]
COPY ["Services/UserService/UserService.Application/UserService.Application.csproj", "Services/UserService/UserService.Application/"]
COPY ["Services/UserService/UserService.Domain/UserService.Domain.csproj", "Services/UserService/UserService.Domain/"]
COPY ["Services/UserService/UserService.Infrastructure/UserService.Infrastructure.csproj", "Services/UserService/UserService.Infrastructure/"]
COPY ["Services/UserService/UserService.Persistence/UserService.Persistence.csproj", "Services/UserService/UserService.Persistence/"]
RUN dotnet restore "Services/UserService/UserService.WebAPI/UserService.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/UserService/UserService.WebAPI"
RUN dotnet build "UserService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.WebAPI.dll"]