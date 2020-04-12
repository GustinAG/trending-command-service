#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trending.Command.Api.Tests/Trending.Command.Api.Tests.csproj", "Trending.Command.Api.Tests/"]
RUN dotnet restore "Trending.Command.Api.Tests/Trending.Command.Api.Tests.csproj"
COPY . .
WORKDIR "/src/Trending.Command.Api.Tests"
RUN dotnet build "Trending.Command.Api.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trending.Command.Api.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trending.Command.Api.Tests.dll"]