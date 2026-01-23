FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Phetolo.Math28.HealthChecks.csproj", "HealthChecks/"]
RUN dotnet restore "HealthChecks/Phetolo.Math28.HealthChecks.csproj"
COPY . .
WORKDIR "/src/HealthChecks"
RUN dotnet build "Phetolo.Math28.HealthChecks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Phetolo.Math28.HealthChecks.csproj" -c Release -o /app/publish /p:UseAppHost=false