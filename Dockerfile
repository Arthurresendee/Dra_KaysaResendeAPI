FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["*.csproj", "./"]
RUN dotnet restore "./drakaysa.csproj"

COPY . .
RUN dotnet build "./drakaysa.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./drakaysa.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Criar diretório para o banco SQLite com permissões adequadas
RUN mkdir -p /app/Data && chmod -R 777 /app/Data

# Corrigir permissões para o SQLite
RUN touch /app/app.db && chmod 777 /app/app.db

ENTRYPOINT ["dotnet", "drakaysa.dll"]
