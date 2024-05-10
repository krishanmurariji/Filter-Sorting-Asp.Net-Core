FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/TodayTest.Web.Host/TodayTest.Web.Host.csproj", "src/TodayTest.Web.Host/"]
COPY ["src/TodayTest.Web.Core/TodayTest.Web.Core.csproj", "src/TodayTest.Web.Core/"]
COPY ["src/TodayTest.Application/TodayTest.Application.csproj", "src/TodayTest.Application/"]
COPY ["src/TodayTest.Core/TodayTest.Core.csproj", "src/TodayTest.Core/"]
COPY ["src/TodayTest.EntityFrameworkCore/TodayTest.EntityFrameworkCore.csproj", "src/TodayTest.EntityFrameworkCore/"]
WORKDIR "/src/src/TodayTest.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/TodayTest.Web.Host", "src/TodayTest.Web.Host"]
COPY ["src/TodayTest.Web.Core", "src/TodayTest.Web.Core"]
COPY ["src/TodayTest.Application", "src/TodayTest.Application"]
COPY ["src/TodayTest.Core", "src/TodayTest.Core"]
COPY ["src/TodayTest.EntityFrameworkCore", "src/TodayTest.EntityFrameworkCore"]
WORKDIR "/src/src/TodayTest.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TodayTest.Web.Host.dll"]
