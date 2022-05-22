#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IronXLFolder/Docker5IronXLLinuxDebian10/Docker5IronXLLinuxDebian10.csproj", "IronXLFolder/Docker5IronXLLinuxDebian10/"]
RUN dotnet restore "IronXLFolder/Docker5IronXLLinuxDebian10/Docker5IronXLLinuxDebian10.csproj"
COPY . .
WORKDIR "/src/IronXLFolder/Docker5IronXLLinuxDebian10"
RUN dotnet build "Docker5IronXLLinuxDebian10.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker5IronXLLinuxDebian10.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker5IronXLLinuxDebian10.dll"]