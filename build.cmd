"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Release /p:Platform="Any CPU" /v:n /target:Clean /flp:logfile=BuildReleaseClean.log;verbosity=normal
"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:n /target:Clean /flp:logfile=BuildDebugClean.log;verbosity=normal

"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Release /p:Platform="Any CPU" /v:n /flp:logfile=BuildRelease.log;verbosity=normal
"c:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" ImageSearch.sln /p:Configuration=Debug /p:Platform="Any CPU" /v:n /flp:logfile=BuildDebug.log;verbosity=normal