#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trending.Command.Api/Trending.Command.Api.csproj", "Trending.Command.Api/"]
COPY ["Trending.Command.Repositories/Trending.Command.Repositories.csproj", "Trending.Command.Repositories/"]
COPY ["Trending.Command.Contracts/Trending.Command.Contracts.csproj", "Trending.Command.Contracts/"]
COPY ["Trending.Command.BusinessLogic/Trending.Command.BusinessLogic.csproj", "Trending.Command.BusinessLogic/"]
RUN dotnet restore "Trending.Command.Api/Trending.Command.Api.csproj"
COPY . .
WORKDIR "/src/Trending.Command.Api"
RUN dotnet build "Trending.Command.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trending.Command.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trending.Command.Api.dll"]
