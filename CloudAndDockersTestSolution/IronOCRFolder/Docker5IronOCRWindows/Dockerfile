#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM mcr.microsoft.com/windows/servercore:ltsc2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IronOCRFolder/Docker5IronOCRWindows/Docker5IronOCRWindows.csproj", "IronOCRFolder/Docker5IronOCRWindows/"]
RUN dotnet restore "IronOCRFolder/Docker5IronOCRWindows/Docker5IronOCRWindows.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker5IronOCRWindows"
RUN dotnet build "Docker5IronOCRWindows.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker5IronOCRWindows.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker5IronOCRWindows.dll"]