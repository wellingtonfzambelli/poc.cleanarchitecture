# ---------- Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# ---------- Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo (porque Clean Architecture tem múltiplos projetos)
COPY . .

# Restaura a solução
RUN dotnet restore CleanArchitecture/CleanArchitecture.sln

# Publica a API
RUN dotnet publish CleanArchitecture/CleanArchitecture.Presentation.Api/CleanArchitecture.Presentation.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ---------- Final ----------
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Presentation.Api.dll"]
