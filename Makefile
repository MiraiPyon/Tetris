# Path to dotnet executable. Override if not in PATH.
DOTNET = "C:\Program Files\dotnet\dotnet.exe"

.PHONY: all build run clean

all: build

build:
	$(DOTNET) build -c Release

run:
	$(DOTNET) run -c Release

clean:
	$(DOTNET) clean
