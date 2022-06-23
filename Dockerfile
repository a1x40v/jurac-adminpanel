# syntax=docker/dockerfile:1

# Build client app image
FROM node:18 as node-build-env
WORKDIR /node

COPY ./client/package.json ./
COPY ./client/package-lock.json ./
RUN npm install --silent

COPY ./client/ ./
RUN npm run build


# Build backend project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-build-env
WORKDIR /app

COPY ./server/JuracAdminpanel.sln ./
COPY ./server/src/API/API.csproj ./src/API/
COPY ./server/src/Domain/Domain.csproj ./src/Domain/
COPY ./server/src/Application/Application.csproj ./src/Application/
COPY ./server/src/Persistence/Persistence.csproj ./src/Persistence/
COPY ./server/src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY ./server/src/Identity/Identity.csproj ./src/Identity/
COPY ./server/tests/IntegrationTests/IntegrationTests.csproj ./tests/IntegrationTests/
RUN dotnet restore

COPY ./server .
RUN dotnet publish -c Release -o out

COPY ./server/src/Infrastructure/Assets ./out/assets

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        zlib1g \
        fontconfig \
        libfreetype6 \
        libx11-6 \
        libxext6 \
        libxrender1 \
        curl \
    && curl -o /usr/lib/libwkhtmltox.so \
        --location \
        https://github.com/rdvojmoc/DinkToPdf/raw/v1.0.8/v0.12.4/64%20bit/libwkhtmltox.so

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

WORKDIR /app
COPY --from=dotnet-build-env /app/out .
COPY --from=node-build-env /node/build ./wwwroot
ENTRYPOINT ["dotnet", "API.dll"]