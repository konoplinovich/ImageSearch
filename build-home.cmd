"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Release /p:Platform="Any CPU" /v:n /target:Clean /flp:logfile=BuildReleaseClean.log;verbosity=normal
"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:n /target:Clean /flp:logfile=BuildDebugClean.log;verbosity=normal

"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Release /p:Platform="Any CPU" /v:n /flp:logfile=BuildRelease.log;verbosity=normal
"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:n /flp:logfile=BuildDebug.log;verbosity=normal

copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\ClosedXML.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\DocumentFormat.OpenXml.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\FileCollector.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\ImageIndex.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\ImageSearch.exe w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\IOTools.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Debug\XlsxModifier.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Debug\

copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\ClosedXML.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\DocumentFormat.OpenXml.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\FileCollector.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\ImageIndex.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\ImageSearch.exe w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\IOTools.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\
copy w:\dev\workspace\Developed\ImageSearch\ImageSearch.WPF\bin\Release\XlsxModifier.dll w:\dev\workspace\Developed\ImageSearch\ImageSearch.Deploy\Release\

pause