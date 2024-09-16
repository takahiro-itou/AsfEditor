
REM msbuild -restore -t:Rebuild -p:Configuration="Release" -p:Platform=x64
msbuild -restore -t:Rebuild -p:Configuration="Debug"   -p:Platform=x86
msbuild -restore -t:Rebuild -p:Configuration="Release" -p:Platform=x86
