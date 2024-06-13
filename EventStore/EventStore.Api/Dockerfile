#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8001
EXPOSE 9001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EventStore/EventStore.Api/EventStore.Api.csproj", "EventStore/EventStore.Api/"]
COPY ["EventStore/EventStore.Application/EventStore.Application.csproj", "EventStore/EventStore.Application/"]
COPY ["EventStore/EventStore.Core/EventStore.Core.csproj", "EventStore/EventStore.Core/"]
COPY ["EventStore/EventStore.Infrastructure/EventStore.Infrastructure.csproj", "EventStore/EventStore.Infrastructure/"]
RUN dotnet restore "./EventStore/EventStore.Api/./EventStore.Api.csproj"
COPY . .
WORKDIR "/src/EventStore/EventStore.Api"
RUN dotnet build "./EventStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EventStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventStore.Api.dll"]