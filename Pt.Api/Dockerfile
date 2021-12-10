FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pt.Api/Pt.Api.csproj", "Pt.Api/"]
COPY ["Pt.Api/packages.lock.json", "Pt.Api/"]
RUN dotnet restore "Pt.Api/Pt.Api.csproj" --locked-mode
COPY . .
WORKDIR "/src/Pt.Api"
RUN dotnet build "Pt.Api.csproj" -c Release # --no-restore 
# /usr/share/dotnet/sdk/6.0.100/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(267,5): error NETSDK1064: Package Microsoft.EntityFrameworkCore.Analyzers, version 6.0.0 was not found. It might have been deleted since NuGet restore. Otherwise, NuGet restore might have only partially completed, which might have been due to maximum path length restrictions.

FROM build AS publish
RUN dotnet publish "Pt.Api.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pt.Api.dll"]
