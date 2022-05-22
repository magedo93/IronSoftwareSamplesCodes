#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# install necessary packages
RUN apt update \
    && apt install -y libc6 libc6-dev libgtk2.0-0 libnss3 libatk-bridge2.0-0 libx11-xcb1 libxcb-dri3-0 libdrm-common libgbm1 libasound2 libappindicator3-1 libxrender1 libfontconfig1 libxshmfence1
# update write permissions
RUN chmod 777 .

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["IronPdfFolder/LinuxUbunto20Docker31IronPdf/LinuxUbunto20Docker31IronPdf.csproj", "IronPdfFolder/LinuxUbunto20Docker31IronPdf/"]
RUN dotnet restore "IronPdfFolder/LinuxUbunto20Docker31IronPdf/LinuxUbunto20Docker31IronPdf.csproj"
COPY . .
WORKDIR "/src/IronPdfFolder/LinuxUbunto20Docker31IronPdf"
RUN dotnet build "LinuxUbunto20Docker31IronPdf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxUbunto20Docker31IronPdf.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxUbunto20Docker31IronPdf.dll"]