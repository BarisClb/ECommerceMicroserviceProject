FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/BasketService/BasketService.WebAPI/BasketService.WebAPI.csproj", "Services/BasketService/BasketService.WebAPI/"]
COPY ["Shared/SharedLibrary/SharedLibrary.csproj", "Shared/SharedLibrary/"]
COPY ["Services/BasketService/BasketService.Application/BasketService.Application.csproj", "Services/BasketService/BasketService.Application/"]
RUN dotnet restore "Services/BasketService/BasketService.WebAPI/BasketService.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/BasketService/BasketService.WebAPI"
RUN dotnet build "BasketService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketService.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketService.WebAPI.dll"]