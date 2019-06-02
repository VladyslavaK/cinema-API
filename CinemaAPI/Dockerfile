FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

ENV DOTNET_USE_POLLING_FILE_WATCHER 1

WORKDIR /app

COPY . ./
RUN dotnet restore

EXPOSE 1001
EXPOSE 1002

CMD dotnet watch --project CinemaAPI/ run  --urls=http://+:1002