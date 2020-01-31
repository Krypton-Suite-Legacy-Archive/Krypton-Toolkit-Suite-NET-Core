set tfm1=%1
set tfm2=%2

cd..

ildasm /nobar "Bin\Release\%tfm1%\Krypton.Toolkit.dll"   /out="Bin\Release\%tfm1%\Krypton.Toolkit.il"
ildasm /nobar "Bin\Release\%tfm1%\Krypton.Ribbon.dll"    /out="Bin\Release\%tfm1%\Krypton.Ribbon.il"
ildasm /nobar "Bin\Release\%tfm1%\Krypton.Docking.dll"   /out="Bin\Release\%tfm1%\Krypton.Docking.il
ildasm /nobar "Bin\Release\%tfm1%\Krypton.Workspace.dll" /out="Bin\Release\%tfm1%\Krypton.Workspace.il"
ildasm /nobar "Bin\Release\%tfm1%\Krypton.Navigator.dll" /out="Bin\Release\%tfm1%\Krypton.Navigator.il"

ildasm /nobar "Bin\Release\%tfm2%\Krypton.Toolkit.dll"   /out="Bin\Release\%tfm2%\Krypton.Toolkit.il"
ildasm /nobar "Bin\Release\%tfm2%\Krypton.Ribbon.dll"    /out="Bin\Release\%tfm2%\Krypton.Ribbon.il"
ildasm /nobar "Bin\Release\%tfm2%\Krypton.Docking.dll"   /out="Bin\Release\%tfm2%\Krypton.Docking.il
ildasm /nobar "Bin\Release\%tfm2%\Krypton.Workspace.dll" /out="Bin\Release\%tfm2%\Krypton.Workspace.il"
ildasm /nobar "Bin\Release\%tfm2%\Krypton.Navigator.dll" /out="Bin\Release\%tfm2%\Krypton.Navigator.il"

fc /w  "Bin\Release\%tfm1%\Krypton.Toolkit.il"    "Bin\Release\%tfm2%\Krypton.Toolkit.il"   > "Ildasm\Krypton.Toolkit.diff-%tfm1%-%tfm2%.txt"
fc /w  "Bin\Release\%tfm1%\Krypton.Ribbon.il"     "Bin\Release\%tfm2%\Krypton.Ribbon.il"    > "Ildasm\Krypton.Ribbon.diff-%tfm1%-%tfm2%.txt"
fc /w  "Bin\Release\%tfm1%\Krypton.Docking.il"    "Bin\Release\%tfm2%\Krypton.Docking.il"   > "Ildasm\Krypton.Docking.diff-%tfm1%-%tfm2%.txt"
fc /w  "Bin\Release\%tfm1%\Krypton.Workspace.il"  "Bin\Release\%tfm2%\Krypton.Workspace.il" > "Ildasm\Krypton.Workspace.diff-%tfm1%-%tfm2%.txt"
fc /w  "Bin\Release\%tfm1%\Krypton.Navigator.il"  "Bin\Release\%tfm2%\Krypton.Navigator.il" > "Ildasm\Krypton.Navigator.diff-%tfm1%-%tfm2%.txt"

cd ildasm