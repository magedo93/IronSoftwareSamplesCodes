#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# install necessary packages
RUN apt update \
    && apt install -y libc6 libc6-dev libgtk2.0-0 libnss3 libatk-bridge2.0-0 libx11-xcb1 libxcb-dri3-0 libdrm-common libgbm1 libasound2 libappindicator3-1 libxrender1 libfontconfig1 libxshmfence1
# update write permissions
RUN chmod 777 .

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IronPdfFolder/LinuxDebian10Docker31IronPdf/LinuxDebian10Docker31IronPdf.csproj", "IronPdfFolder/LinuxDebian10Docker31IronPdf/"]
RUN dotnet restore "IronPdfFolder/LinuxDebian10Docker31IronPdf/LinuxDebian10Docker31IronPdf.csproj"
COPY . .
WORKDIR "/src/IronPdfFolder/LinuxDebian10Docker31IronPdf"
RUN dotnet build "LinuxDebian10Docker31IronPdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxDebian10Docker31IronPdf.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxDebian10Docker31IronPdf.dll"]