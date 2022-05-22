#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src
COPY ["IronOCRFolder/Docker31IronOCRLinuxDebian11/Docker31IronOCRLinuxDebian11.csproj", "IronOCRFolder/Docker31IronOCRLinuxDebian11/"]
RUN dotnet restore "IronOCRFolder/Docker31IronOCRLinuxDebian11/Docker31IronOCRLinuxDebian11.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker31IronOCRLinuxDebian11"
RUN dotnet build "Docker31IronOCRLinuxDebian11.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker31IronOCRLinuxDebian11.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker31IronOCRLinuxDebian11.dll"]