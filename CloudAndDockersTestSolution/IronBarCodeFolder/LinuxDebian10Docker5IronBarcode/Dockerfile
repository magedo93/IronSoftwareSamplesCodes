#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y libgdiplus

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IronBarCodeFolder/LinuxDebian10Docker5IronBarcode/LinuxDebian10Docker5IronBarcode.csproj", "IronBarCodeFolder/LinuxDebian10Docker5IronBarcode/"]
RUN dotnet restore "IronBarCodeFolder/LinuxDebian10Docker5IronBarcode/LinuxDebian10Docker5IronBarcode.csproj"
COPY . .
WORKDIR "/src/IronBarCodeFolder/LinuxDebian10Docker5IronBarcode"
RUN dotnet build "LinuxDebian10Docker5IronBarcode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxDebian10Docker5IronBarcode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxDebian10Docker5IronBarcode.dll"]