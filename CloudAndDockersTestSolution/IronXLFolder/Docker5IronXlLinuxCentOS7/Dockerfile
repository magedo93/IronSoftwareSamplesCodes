#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM centos:7  AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN yum install sudo  -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-5.0  -y
RUN sudo yum install aspnetcore-runtime-5.0 -y
RUN sudo yum install dotnet-runtime-5.0  -y

WORKDIR /src
COPY ["IronXLFolder/Docker5IronXlLinuxCentOS7/Docker5IronXlLinuxCentOS7.csproj", "IronXLFolder/Docker5IronXlLinuxCentOS7/"]
RUN dotnet restore "IronXLFolder/Docker5IronXlLinuxCentOS7/Docker5IronXlLinuxCentOS7.csproj"
COPY . .
WORKDIR "/src/IronXLFolder/Docker5IronXlLinuxCentOS7"
RUN dotnet build "Docker5IronXlLinuxCentOS7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker5IronXlLinuxCentOS7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker5IronXlLinuxCentOS7.dll"]