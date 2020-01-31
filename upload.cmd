@echo off

:: This script is designed to upload new versions to NuGet. This will not work without the API key (UNDER CONSTRUCTION)


:yes
nuget push Krypton.Docking.5.500.2002.nupkg

nuget push Krypton.Docking.Lite.5.500.2002.nupkg

nuget push Krypton.Navigator.5.500.2002.nupkg

nuget push Krypton.Navigator.Lite.5.500.2002.nupkg

nuget push Krypton.Ribbon.5.500.2002.nupkg

nuget push Krypton.Ribbon.Lite.5.500.2002.nupkg

nuget push Krypton.Toolkit.5.500.2002.nupkg

nuget push Krypton.Toolkit.Lite.5.500.2002.nupkg

nuget push Krypton.Workspace.5.500.2002.nupkg

nuget push Krypton.Workspace.Lite.5.500.2002.nupkg

:no


:deletepackages


pause