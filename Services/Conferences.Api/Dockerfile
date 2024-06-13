#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8000
EXPOSE 9000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Conferences.Api/Conferences.Api.csproj", "Services/Conferences.Api/"]
COPY ["Services/Conferences.Application/Conferences.Application.csproj", "Services/Conferences.Application/"]
COPY ["Services/Conferences.Domain/Conferences.Domain.csproj", "Services/Conferences.Domain/"]
RUN dotnet restore "./Services/Conferences.Api/./Conferences.Api.csproj"
COPY . .
WORKDIR "/src/Services/Conferences.Api"
RUN dotnet build "./Conferences.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Conferences.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Conferences.Api.dll"]