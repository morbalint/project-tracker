FROM mcr.microsoft.com/dotnet/sdk:6.0 AS test
WORKDIR /src
COPY ["ProjectTracker.Api/ProjectTracker.Api.csproj", "ProjectTracker.Api/"]
COPY ["ProjectTracker.Api/packages.lock.json", "ProjectTracker.Api/"]
COPY ["ProjectTracker.Api.Unit.Tests/ProjectTracker.Api.Unit.Tests.csproj", "ProjectTracker.Api.Unit.Tests/"]
COPY ["ProjectTracker.Api.Unit.Tests/packages.lock.json", "ProjectTracker.Api.Unit.Tests/"]
RUN dotnet restore "ProjectTracker.Api.Unit.Tests/ProjectTracker.Api.Unit.Tests.csproj" --locked-mode
COPY . .
RUN dotnet build "ProjectTracker.Api.Unit.Tests/ProjectTracker.Api.Unit.Tests.csproj" --no-restore
RUN dotnet test "ProjectTracker.Api.Unit.Tests/ProjectTracker.Api.Unit.Tests.csproj" --no-build