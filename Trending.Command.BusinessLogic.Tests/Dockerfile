#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trending.Command.BusinessLogic.Tests/Trending.Command.BusinessLogic.Tests.csproj", "Trending.Command.BusinessLogic.Tests/"]
COPY ["Trending.Command.BusinessLogic/Trending.Command.BusinessLogic.csproj", "Trending.Command.BusinessLogic/"]
COPY ["Trending.Command.Contracts/Trending.Command.Contracts.csproj", "Trending.Command.Contracts/"]
RUN dotnet restore "Trending.Command.BusinessLogic.Tests/Trending.Command.BusinessLogic.Tests.csproj"
COPY . .
WORKDIR "/src/Trending.Command.BusinessLogic.Tests"
RUN dotnet build "Trending.Command.BusinessLogic.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trending.Command.BusinessLogic.Tests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trending.Command.BusinessLogic.Tests.dll"]