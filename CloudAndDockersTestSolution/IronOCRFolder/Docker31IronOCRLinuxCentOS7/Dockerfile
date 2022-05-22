#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM centos:7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN yum install sudo  -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1  -y
RUN sudo yum install aspnetcore-runtime-3.1  -y
RUN sudo yum install dotnet-runtime-3.1  -y
RUN sudo yum update -y
RUN yum install epel-release -y
RUN sudo yum install mono-complete -y
RUN sudo yum install libgdiplus libc6-dev -y
#RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev
WORKDIR /src
COPY ["IronOCRFolder/Docker31IronOCRLinuxCentOS7/Docker31IronOCRLinuxCentOS7.csproj", "IronOCRFolder/Docker31IronOCRLinuxCentOS7/"]
RUN dotnet restore "IronOCRFolder/Docker31IronOCRLinuxCentOS7/Docker31IronOCRLinuxCentOS7.csproj"
COPY . .
WORKDIR "/src/IronOCRFolder/Docker31IronOCRLinuxCentOS7"
RUN dotnet build "Docker31IronOCRLinuxCentOS7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker31IronOCRLinuxCentOS7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker31IronOCRLinuxCentOS7.dll"]