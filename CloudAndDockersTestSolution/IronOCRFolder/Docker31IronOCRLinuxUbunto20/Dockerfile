#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#NAME="Ubuntu" VERSION="20.04.3 LTS (Focal Fossa)"

FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["IronOCRFolder/Docker31IronOCRLinuxUbunto20/Docker31IronOCRLinuxUbunto20.csproj", "IronOCRFolder/Docker31IronOCRLinuxUbunto20/"]
RUN dotnet restore "IronOCRFolder/Docker31IronOCRLinuxUbunto20/Docker31IronOCRLinuxUbunto20.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker31IronOCRLinuxUbunto20"
RUN dotnet build "Docker31IronOCRLinuxUbunto20.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker31IronOCRLinuxUbunto20.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker31IronOCRLinuxUbunto20.dll"]