dotnet-sonarscanner.exe begin /k:"footballista" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="dc02de1c7601f3372f75578533ad74ae057950a2"  /d:sonar.cs.opencover.reportsPaths="TestResults\*\coverage.opencover.xml" -d:sonar.cs.vstest.reportsPaths="TestResults\*.trx"
dotnet build
dotnet test .\Footballista.BuildingBlocks.Domain.UnitTests\Footballista.BuildingBlocks.Domain.UnitTests.csproj --settings coverlet.runsettings --logger trx --results-directory .\TestResults
dotnet test .\Footballista.Wasm.Shared.UnitTests\Footballista.Wasm.Shared.UnitTests.csproj --settings coverlet.runsettings --logger trx --results-directory .\TestResults
dotnet-sonarscanner.exe end /d:sonar.login="dc02de1c7601f3372f75578533ad74ae057950a2"