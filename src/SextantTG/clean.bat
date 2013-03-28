copy /Y SextantTG.ServerTest\bin\Debug\log4net.config ..\..\bin\
del /F /S /Q *.pdb *.dll *.cache *.force *.resources *.exe *csproj*.txt *exe.config *.manifest
del /F /S /Q *.xml log4net.config *.log
copy /Y ..\..\bin\log4net.config SextantTG.Util\
