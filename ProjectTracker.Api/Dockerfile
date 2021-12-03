FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjectTracker.Api/ProjectTracker.Api.csproj", "ProjectTracker.Api/"]
RUN dotnet restore "ProjectTracker.Api/ProjectTracker.Api.csproj" --locked-mode
COPY . .
WORKDIR "/src/ProjectTracker.Api"
RUN dotnet build "ProjectTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectTracker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectTracker.Api.dll"]
