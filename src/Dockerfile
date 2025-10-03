FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ARG GIT_TAG=0.0.0

WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -o out -p:FileVersion=${GIT_TAG}

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8080

ENTRYPOINT ["dotnet", "HeaderAudit.dll"]
