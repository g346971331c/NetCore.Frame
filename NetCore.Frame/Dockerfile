#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NetCore.Frame/NetCore.Frame.csproj", "NetCore.Frame/"]
RUN dotnet restore "NetCore.Frame/NetCore.Frame.csproj"
COPY . .
WORKDIR "/src/NetCore.Frame"
RUN dotnet build "NetCore.Frame.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore.Frame.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore.Frame.dll"]