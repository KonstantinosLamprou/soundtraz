# ------------ Phase 1: Build -------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Projektdateien kopieren
COPY ["BrigdeService.Api/BrigdeService.Api.csproj", "BrigdeService.Api/"]
COPY ["BrigdeService.Infrastructure/BrigdeService.Infrastructure.csproj", "BrigdeService.Infrastructure/"]
COPY ["BrigdeService.Application/BrigdeService.Application.csproj", "BrigdeService.Application/"]
COPY ["BrigdeService.Domain/BrigdeService.Domain.csproj", "BrigdeService.Domain/"]

RUN dotnet restore "BrigdeService.Api/BrigdeService.Api.csproj"

# Restlichen Code kopieren und publishen
COPY . .
RUN dotnet publish "BrigdeService.Api/BrigdeService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ------------- Phase 2: Run -------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble AS final
WORKDIR /app

# .NET 8+ Standardport
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BrigdeService.Api.dll"]