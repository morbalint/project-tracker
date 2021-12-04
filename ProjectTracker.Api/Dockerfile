FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjectTracker.Db/ProjectTracker.Db.csproj", "ProjectTracker.Db/"]
COPY ["ProjectTracker.Db/packages.lock.json", "ProjectTracker.Db/"]
COPY ["ProjectTracker.Api/ProjectTracker.Api.csproj", "ProjectTracker.Api/"]
COPY ["ProjectTracker.Api/packages.lock.json", "ProjectTracker.Api/"]
RUN dotnet restore "ProjectTracker.Api/ProjectTracker.Api.csproj" --locked-mode
COPY . .
WORKDIR "/src/ProjectTracker.Api"
RUN dotnet build "ProjectTracker.Api.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectTracker.Api.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectTracker.Api.dll"]
