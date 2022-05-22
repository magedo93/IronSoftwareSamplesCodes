#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#PRETTY_NAME="Debian GNU/Linux 10 (buster)"

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IronOCRFolder/Docker31IronOCRLinuxDebian10/Docker31IronOCRLinuxDebian10.csproj", "IronOCRFolder/Docker31IronOCRLinuxDebian10/"]
RUN dotnet restore "IronOCRFolder/Docker31IronOCRLinuxDebian10/Docker31IronOCRLinuxDebian10.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker31IronOCRLinuxDebian10"
RUN dotnet build "Docker31IronOCRLinuxDebian10.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker31IronOCRLinuxDebian10.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker31IronOCRLinuxDebian10.dll"]