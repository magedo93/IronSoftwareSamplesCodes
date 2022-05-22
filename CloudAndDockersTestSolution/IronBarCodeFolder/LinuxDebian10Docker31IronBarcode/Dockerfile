#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y libgdiplus

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LinuxDebian10Docker31IronBarcode/LinuxDebian10Docker31IronBarcode.csproj", "LinuxDebian10Docker31IronBarcode/"]
RUN dotnet restore "LinuxDebian10Docker31IronBarcode/LinuxDebian10Docker31IronBarcode.csproj"
COPY . .
WORKDIR "/src/LinuxDebian10Docker31IronBarcode"
RUN dotnet build "LinuxDebian10Docker31IronBarcode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxDebian10Docker31IronBarcode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxDebian10Docker31IronBarcode.dll"]