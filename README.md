# Header Audit

This is a simple project that creates a webpage to return the request headers given as a JSON response.

## Build

```bash
dotnet build ./src/BinaryPatrick.HeaderAudit.csproj -o out/
dotnet ./out/src/BinaryPatrick.HeaderAudit.dll
```

```bash
docker build -t header-audit -f ./src/Dockerfile ./src
docker run -p 8080:8080 header-audit
```

## Docker Hub

Image found at https://hub.docker.com/r/binarypatrick/header-audit
