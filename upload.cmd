@echo off

:: This script is designed to upload new versions to NuGet. This will not work without the API key (UNDER CONSTRUCTION)

echo Before uploading packages, it is suggested that you are using the latest NuGet packager. Do you want to check for updates now? (Y/N)
set INPUT=
set /P INPUT=Type input: %=%
If /I "%INPUT%"=="y" goto updateself
::If /I "%INPUT%"=="n" goto no

:yes
cd Bin\Release

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
echo You have chosen to abandon the upload process. Please run upload.cmd from a command line promt when ready!

pause

:updateself
nuget update -self

pause