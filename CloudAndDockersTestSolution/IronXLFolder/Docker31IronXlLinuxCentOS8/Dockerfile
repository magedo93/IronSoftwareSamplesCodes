#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM centos:8  AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN yum install sudo  -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1  -y
RUN sudo yum install aspnetcore-runtime-3.1  -y
RUN sudo yum install dotnet-runtime-3.1  -y
WORKDIR /src
COPY ["IronXLFolder/Docker31IronXlLinuxCentOS8/Docker31IronXlLinuxCentOS8.csproj", "IronXLFolder/Docker31IronXlLinuxCentOS8/"]
RUN dotnet restore "IronXLFolder/Docker31IronXlLinuxCentOS8/Docker31IronXlLinuxCentOS8.csproj"
COPY . .
WORKDIR "/src/IronXLFolder/Docker31IronXlLinuxCentOS8"
RUN dotnet build "Docker31IronXlLinuxCentOS8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker31IronXlLinuxCentOS8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker31IronXlLinuxCentOS8.dll"]