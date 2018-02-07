if (Test-Path Demo) {
    Remove-Item Demo -Recurse -Force
}

md Demo
cd Demo
md DatingApp
cd DatingApp

dotnet new webapi -o DatingApp.API -n DatingApp.API

$env:ASPNETCORE_ENVIRONMENT = "Development"
cd $PSScriptRoot