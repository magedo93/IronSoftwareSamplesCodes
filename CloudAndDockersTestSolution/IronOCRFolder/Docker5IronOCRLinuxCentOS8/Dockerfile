#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM centos:8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN yum install sudo  -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-5.0  -y
RUN sudo yum install aspnetcore-runtime-5.0  -y
RUN sudo yum install dotnet-runtime-5.0  -y
RUN sudo yum update -y
RUN yum install epel-release -y
RUN sudo yum install mono-complete -y
RUN sudo yum install libgdiplus libc6-dev -y
WORKDIR /src
COPY ["IronOCRFolder/Docker5IronOCRLinuxCentOS8/Docker5IronOCRLinuxCentOS8.csproj", "IronOCRFolder/Docker5IronOCRLinuxCentOS8/"]
RUN dotnet restore "IronOCRFolder/Docker5IronOCRLinuxCentOS8/Docker5IronOCRLinuxCentOS8.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker5IronOCRLinuxCentOS8"
RUN dotnet build "Docker5IronOCRLinuxCentOS8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker5IronOCRLinuxCentOS8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker5IronOCRLinuxCentOS8.dll"]