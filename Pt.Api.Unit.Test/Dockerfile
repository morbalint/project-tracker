FROM mcr.microsoft.com/dotnet/sdk:6.0 AS test
WORKDIR /src
COPY ["Pt.Db/Pt.Db.csproj", "Pt.Db/"]
COPY ["Pt.Db/packages.lock.json", "Pt.Db/"]
COPY ["Pt.Api/Pt.Api.csproj", "Pt.Api/"]
COPY ["Pt.Api/packages.lock.json", "Pt.Api/"]
COPY ["Pt.Api.Unit.Test/Pt.Api.Unit.Test.csproj", "Pt.Api.Unit.Test/"]
COPY ["Pt.Api.Unit.Test/packages.lock.json", "Pt.Api.Unit.Test/"]
RUN dotnet restore "Pt.Api.Unit.Test/Pt.Api.Unit.Test.csproj" --locked-mode
COPY . .
RUN dotnet build "Pt.Api.Unit.Test/Pt.Api.Unit.Test.csproj" --no-restore
RUN dotnet test "Pt.Api.Unit.Test/Pt.Api.Unit.Test.csproj" --no-build