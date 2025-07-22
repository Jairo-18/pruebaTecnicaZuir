# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia archivos y restaura dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto y construye
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expón el puerto de la app
EXPOSE 8080

# Ejecuta la app
ENTRYPOINT ["dotnet", "PruebaTecnica.dll"]
