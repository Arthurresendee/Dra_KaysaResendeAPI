FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar o arquivo .csproj diretamente para o contêiner
COPY ["drakaysa.csproj", "./"]

# Restaurar dependências
RUN dotnet restore "./drakaysa.csproj"

# Copiar o restante dos arquivos para o contêiner
COPY . .

# Compilar o projeto
RUN dotnet build "./drakaysa.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publicar o projeto
RUN dotnet publish "./drakaysa.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=publish /app/publish .

# Definir o ponto de entrada do contêiner
ENTRYPOINT ["dotnet", "drakaysa.dll"]
