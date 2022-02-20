FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5022
EXPOSE 5023

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MiniGrpc.Server/MiniGrpc.Server.csproj", "MiniGrpc.Server/"]
RUN dotnet restore "MiniGrpc.Server"
COPY . .
WORKDIR "/src/"
RUN dotnet build "MiniGrpc.Server" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniGrpc.Server" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniGrpc.Server.dll"]
