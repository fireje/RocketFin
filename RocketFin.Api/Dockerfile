FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /App
ARG ENV
ENV DOTNET_ENVIRONMENT=$ENV
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "RocketFin.Api.dll"]