FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pt.Api.Acceptance.Tests/Pt.Api.Acceptance.Tests.csproj", "Pt.Api.Acceptance.Tests/"]
COPY ["Pt.Api.Acceptance.Tests/packages.lock.json", "Pt.Api.Acceptance.Tests/"]
RUN dotnet restore "Pt.Api.Acceptance.Tests/Pt.Api.Acceptance.Tests.csproj" --locked-mode
COPY . .
WORKDIR "/src/Pt.Api.Acceptance.Tests"
RUN dotnet build "Pt.Api.Acceptance.Tests.csproj" # --no-restore 
# /usr/share/dotnet/sdk/6.0.100/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(267,5): error NETSDK1064: Package Microsoft.EntityFrameworkCore.Analyzers, version 6.0.0 was not found. It might have been deleted since NuGet restore. Otherwise, NuGet restore might have only partially completed, which might have been due to maximum path length restrictions.
ENTRYPOINT ["dotnet", "test", "Pt.Api.Acceptance.Tests.csproj", "--verbosity", "normal"]

