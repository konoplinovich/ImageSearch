"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Release /p:Platform="Any CPU" /v:n /target:Clean /flp:logfile=BuildReleaseClean.log;verbosity=normal
"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:n /target:Clean /flp:logfile=BuildDebugClean.log;verbosity=normal

"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Release /p:Platform="Any CPU" /v:n /flp:logfile=BuildRelease.log;verbosity=normal
"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:n /flp:logfile=BuildDebug.log;verbosity=normal

copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\ClosedXML.dll s:\dev\ImageSearch\ImageSearch.Deploy\Debug\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\DocumentFormat.OpenXml.dll s:\dev\ImageSearch\ImageSearch.Deploy\Debug\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\FileCollector.dll s:\dev\ImageSearch\ImageSearch.Deploy\Debug\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\ImageIndex.dll s:\dev\ImageSearch\ImageSearch.Deploy\Debug\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\ImageSearch.exe s:\dev\ImageSearch\ImageSearch.Deploy\Debug\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\IOTools.dll s:\dev\ImageSearch\ImageSearch.Deploy\Debug\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Debug\XlsxModifier.dll s:\dev\ImageSearch\ImageSearch.Deploy\Debug\

copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\ClosedXML.dll s:\dev\ImageSearch\ImageSearch.Deploy\Release\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\DocumentFormat.OpenXml.dll s:\dev\ImageSearch\ImageSearch.Deploy\Release\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\FileCollector.dll s:\dev\ImageSearch\ImageSearch.Deploy\Release\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\ImageIndex.dll s:\dev\ImageSearch\ImageSearch.Deploy\Release\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\ImageSearch.exe s:\dev\ImageSearch\ImageSearch.Deploy\Release\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\IOTools.dll s:\dev\ImageSearch\ImageSearch.Deploy\Release\
copy s:\dev\ImageSearch\ImageSearch.WPF\bin\Release\XlsxModifier.dll s:\dev\ImageSearch\ImageSearch.Deploy\Release\