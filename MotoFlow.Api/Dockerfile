FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["MotoFlow.Api/MotoFlow.Api.csproj", "MotoFlow.Api/"]
RUN dotnet restore "./MotoFlow.Api/MotoFlow.Api.csproj"

COPY . .
WORKDIR "/src/MotoFlow.Api"
RUN dotnet build "./MotoFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./MotoFlow.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MotoFlow.Api.dll"]