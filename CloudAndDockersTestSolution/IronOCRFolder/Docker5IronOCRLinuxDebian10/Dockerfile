#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#PRETTY_NAME="Debian GNU/Linux 10 (buster)"

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IronOCRFolder/Docker5IronOCRLinuxDebian10/Docker5IronOCRLinuxDebian10.csproj", "IronOCRFolder/Docker5IronOCRLinuxDebian10/"]
RUN dotnet restore "IronOCRFolder/Docker5IronOCRLinuxDebian10/Docker5IronOCRLinuxDebian10.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker5IronOCRLinuxDebian10"
RUN dotnet build "Docker5IronOCRLinuxDebian10.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker5IronOCRLinuxDebian10.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker5IronOCRLinuxDebian10.dll"]