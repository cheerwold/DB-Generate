# 使用运行时镜像
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
# 设置工作目录
WORKDIR /app
# 把目录下的内容都复制到当前目录下
COPY . .
# 暴露80端口
EXPOSE 80
# 运行镜像入口命令和可执行文件名称
ENTRYPOINT ["dotnet", "SoEasyPlatform.dll"]

## 在 SoEasyPlatform\bin\Release\netcoreapp3.1 目录下构建镜像
##docker build -t dbg publish/.


##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["SoEasyPlatform/SoEasyPlatform.csproj", "SoEasyPlatform/"]
#RUN dotnet restore "./SoEasyPlatform/SoEasyPlatform.csproj"
#COPY . .
#WORKDIR "/src/SoEasyPlatform"
#RUN dotnet build "./SoEasyPlatform.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./SoEasyPlatform.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "SoEasyPlatform.dll"]
