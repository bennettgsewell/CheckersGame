#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Checkers/Checkers.csproj", "Checkers/"]
RUN dotnet restore "Checkers/Checkers.csproj"
COPY . .

WORKDIR /src/Checkers/ClientApp
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm
RUN npm install

WORKDIR "/src/Checkers"
RUN dotnet build "Checkers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Checkers.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Checkers.dll"]