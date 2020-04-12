#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trending.Command.Repositories.Tests/Trending.Command.Repositories.Tests.csproj", "Trending.Command.Repositories.Tests/"]
COPY ["Trending.Command.Repositories/Trending.Command.Repositories.csproj", "Trending.Command.Repositories/"]
COPY ["Trending.Command.Contracts/Trending.Command.Contracts.csproj", "Trending.Command.Contracts/"]
RUN dotnet restore "Trending.Command.Repositories.Tests/Trending.Command.Repositories.Tests.csproj"
COPY . .
WORKDIR "/src/Trending.Command.Repositories.Tests"
RUN dotnet build "Trending.Command.Repositories.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trending.Command.Repositories.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trending.Command.Repositories.Tests.dll"]