#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Fictivus_API-gateway/Fictivusforum_API-gateway.csproj", "Fictivus_API-gateway/"]
RUN dotnet restore "Fictivus_API-gateway/Fictivusforum_API-gateway.csproj"
COPY . .
WORKDIR "/src/Fictivus_API-gateway"
RUN dotnet build "Fictivusforum_API-gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fictivusforum_API-gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fictivus_API-gateway.dll"]
