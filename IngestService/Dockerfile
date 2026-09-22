# ------------ Phase 1: Build -------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Projektdateien kopieren (ohne den Stammordner, da Docker bereits im Context ./IngestService ist)
COPY ["IngestService.Api/IngestService.Api.csproj", "IngestService.Api/"]
COPY ["IngestService.Infrastructure/IngestService.Infrastructure.csproj", "IngestService.Infrastructure/"]
COPY ["IngestService.Application/IngestService.Application.csproj", "IngestService.Application/"]
COPY ["IngestService.Domain/IngestService.Domain.csproj", "IngestService.Domain/"]

RUN dotnet restore "IngestService.Api/IngestService.Api.csproj"

# Restlichen Code kopieren und publishen
COPY . .
RUN dotnet publish "IngestService.Api/IngestService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ------------- Phase 2: Run -------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble AS final
WORKDIR /app

# .NET 8+ Standardport
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IngestService.Api.dll"]