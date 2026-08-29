# Etapa 1: Imagen base de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Etapa 2: Construcción y publicación (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["evaluacion20262.csproj", "./"]
RUN dotnet restore "evaluacion20262.csproj"
COPY . .
RUN dotnet build "evaluacion20262.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "evaluacion20262.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Imagen final para Render
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "evaluacion20262.dll"]
