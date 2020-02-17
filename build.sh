#!/bin/bash
echo --Runing Unit Tests and Code Coverage
echo
dotnet clean
dotnet build

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat="cobertura" /p:Exclude=[System.*]*%2c[DBLayer]DBLayer.Migrations.* /p:Theshold=80
reportgenerator "-reports:**/coverage.cobertura.xml" "-targetdir:Report" "-reporttypes:Html;Cobertura"


