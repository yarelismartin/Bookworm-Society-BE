# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bookworm-Society-API/Bookworm-Society-API.csproj", "Bookworm-Society-API/"]
RUN dotnet restore "./Bookworm-Society-API/Bookworm-Society-API.csproj"
COPY . .
WORKDIR "/src/Bookworm-Society-API"
RUN dotnet build "./Bookworm-Society-API.csproj" -c $BUILD_CONFIGURATION -o /app/build


# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bookworm-Society-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookworm-Society-API.dll"]