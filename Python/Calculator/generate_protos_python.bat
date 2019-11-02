setlocal

set PROTOS_PATH=Protos
set OUTPUT_PATH=Calculator

if not exist %OUTPUT_PATH% mkdir %OUTPUT_PATH%

for /R . %%f in (%PROTOS_PATH%\*.proto) do (
	python -m grpc_tools.protoc --proto_path=%PROTOS_PATH% --python_out=%OUTPUT_PATH% --grpc_python_out=%OUTPUT_PATH%  %PROTOS_PATH%/%%~nf%%~xf
)

endlocal