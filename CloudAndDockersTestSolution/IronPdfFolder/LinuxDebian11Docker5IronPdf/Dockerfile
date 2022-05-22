#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src
COPY ["IronPdfFolder/LinuxDebian11Docker5IronPdf/LinuxDebian11Docker5IronPdf.csproj", "IronPdfFolder/LinuxDebian11Docker5IronPdf/"]
RUN dotnet restore "IronPdfFolder/LinuxDebian11Docker5IronPdf/LinuxDebian11Docker5IronPdf.csproj"
COPY . .
WORKDIR "/src/IronPdfFolder/LinuxDebian11Docker5IronPdf"
RUN dotnet build "LinuxDebian11Docker5IronPdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxDebian11Docker5IronPdf.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxDebian11Docker5IronPdf.dll"]