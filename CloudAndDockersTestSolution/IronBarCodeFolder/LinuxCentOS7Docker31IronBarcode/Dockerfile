#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

 # base runtime image (CentOS 7)
FROM centos:7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# install necessary packages
RUN yum install sudo  -y
RUN sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN sudo yum install dotnet-sdk-3.1  -y
RUN sudo yum install aspnetcore-runtime-3.1  -y
RUN sudo yum install dotnet-runtime-3.1  -y
RUN sudo yum update -y
RUN yum install epel-release -y
RUN sudo yum install mono-complete -y
RUN sudo yum install libgdiplus libc6-dev -y

WORKDIR /src
COPY ["IronBarCodeFolder/LinuxCentOS7Docker31IronBarcode/LinuxCentOS7Docker31IronBarcode.csproj", "IronBarCodeFolder/LinuxCentOS7Docker31IronBarcode/"]
RUN dotnet restore "IronBarCodeFolder/LinuxCentOS7Docker31IronBarcode/LinuxCentOS7Docker31IronBarcode.csproj"
COPY . .
WORKDIR "/src/IronBarCodeFolder/LinuxCentOS7Docker31IronBarcode"
RUN dotnet build "LinuxCentOS7Docker31IronBarcode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxCentOS7Docker31IronBarcode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxCentOS7Docker31IronBarcode.dll"]