#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y libgdiplus

FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src
COPY ["IronBarCodeFolder/LinuxDebian11Docker31IronBarcode/LinuxDebian11Docker31IronBarcode.csproj", "IronBarCodeFolder/LinuxDebian11Docker31IronBarcode/"]
RUN dotnet restore "IronBarCodeFolder/LinuxDebian11Docker31IronBarcode/LinuxDebian11Docker31IronBarcode.csproj"
COPY . .
WORKDIR "/src/IronBarCodeFolder/LinuxDebian11Docker31IronBarcode"
RUN dotnet build "LinuxDebian11Docker31IronBarcode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxDebian11Docker31IronBarcode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxDebian11Docker31IronBarcode.dll"]