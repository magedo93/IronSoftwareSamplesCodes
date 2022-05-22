#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src
COPY ["IronXLFolder/Docker31IronXLLinuxDebian11/Docker31IronXLLinuxDebian11.csproj", "IronXLFolder/Docker31IronXLLinuxDebian11/"]
RUN dotnet restore "IronXLFolder/Docker31IronXLLinuxDebian11/Docker31IronXLLinuxDebian11.csproj"
COPY . .
WORKDIR "/src/IronXLFolder/Docker31IronXLLinuxDebian11"
RUN dotnet build "Docker31IronXLLinuxDebian11.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker31IronXLLinuxDebian11.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker31IronXLLinuxDebian11.dll"]