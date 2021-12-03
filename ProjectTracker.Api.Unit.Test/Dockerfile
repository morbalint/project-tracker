FROM mcr.microsoft.com/dotnet/sdk:6.0 AS test
WORKDIR /src
COPY ["ProjectTracker.Api/ProjectTracker.Api.csproj", "ProjectTracker.Api/"]
COPY ["ProjectTracker.Api/packages.lock.json", "ProjectTracker.Api/"]
COPY ["ProjectTracker.Api.Unit.Test/ProjectTracker.Api.Unit.Test.csproj", "ProjectTracker.Api.Unit.Test/"]
COPY ["ProjectTracker.Api.Unit.Test/packages.lock.json", "ProjectTracker.Api.Unit.Test/"]
RUN dotnet restore "ProjectTracker.Api.Unit.Test/ProjectTracker.Api.Unit.Test.csproj" --locked-mode
COPY . .
RUN dotnet build "ProjectTracker.Api.Unit.Test/ProjectTracker.Api.Unit.Test.csproj" --no-restore
RUN dotnet test "ProjectTracker.Api.Unit.Test/ProjectTracker.Api.Unit.Test.csproj" --no-build