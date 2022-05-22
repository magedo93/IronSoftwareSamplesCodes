#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IronPdfFolder/LinuxDebian10Docker5IronPdf/LinuxDebian10Docker5IronPdf.csproj", "IronPdfFolder/LinuxDebian10Docker5IronPdf/"]
RUN dotnet restore "IronPdfFolder/LinuxDebian10Docker5IronPdf/LinuxDebian10Docker5IronPdf.csproj"
COPY . .
WORKDIR "/src/IronPdfFolder/LinuxDebian10Docker5IronPdf"
RUN dotnet build "LinuxDebian10Docker5IronPdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxDebian10Docker5IronPdf.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxDebian10Docker5IronPdf.dll"]