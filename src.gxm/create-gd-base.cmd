@echo off
set TPL_DIR=G:\Glacie\glacie-test-data\tpl\
"../src/Cli/gx-md/bin/Debug/netcoreapp3.1/gx-md" --log-level=trace create --metadata="%TPL_DIR%\gd-1.1.7.1" --output=./gd/ --multipart --mp-main=base-0.g.gxmd --mp-include=base-0.g --emit-var-only
"../src/Cli/gx-md/bin/Debug/netcoreapp3.1/gx-md" --log-level=trace create --metadata=./gd/base-0.g.gxmd --output=./gd/ --output-format=gxmp-boilerplate --multipart --mp-main=base-1.g.gxmp --mp-include=base-1.g
