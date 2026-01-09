FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["WebAPI/Phetolo.Math28.API/Phetolo.Math28.API.csproj", "WebAPI/Phetolo.Math28.API/"]
COPY ["WebAPI/Phetolo.Math28.Infrastructure/Phetolo.Math28.Infrastructure.csproj", "WebAPI/Phetolo.Math28.Infrastructure/"]
COPY ["WebAPI/Phetolo.Math28.Application/Phetolo.Math28.Application.csproj", "WebAPI/Phetolo.Math28.Application/"]
COPY ["WebAPI/Phetolo.Math28.Core/Phetolo.Math28.Core.csproj", "WebAPI/Phetolo.Math28.Core/"]
COPY ["Generator/Phetolo.Math28.PuzzleGenerator.csproj", "Generator/"]
RUN dotnet restore "WebAPI/Phetolo.Math28.API/Phetolo.Math28.API.csproj"
COPY . .
WORKDIR "/src/WebAPI/Phetolo.Math28.API"
RUN dotnet build "Phetolo.Math28.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Phetolo.Math28.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Phetolo.Math28.API.dll"]