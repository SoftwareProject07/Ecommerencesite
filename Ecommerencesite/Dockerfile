#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
#COPY . .
#RUN dotnet restore
#RUN dotnet publish -c Release -o /app/publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
#WORKDIR /app
#COPY --from=build /app/publish .
#
#ENV ASPNETCORE_URLS=http://+:8080
#EXPOSE 8080
#
#ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]
#

# Stage 1: Build
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
## Copy solution and project files
#COPY *.sln .
#COPY Ecommerencesite/*.csproj ./Ecommerencesite/
#
## Restore dependencies
#RUN dotnet restore
#
## Copy all source code
#COPY Ecommerencesite/. ./Ecommerencesite/
#
#WORKDIR /src/Ecommerencesite
#
## Build and publish the app
#RUN dotnet publish -c Release -o /app/publish
#
## Stage 2: Runtime
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
#WORKDIR /app
#
## Copy published app from build stage
#COPY --from=build /app/publish .
#
## Set environment variable and expose port
#ENV ASPNETCORE_URLS=http://+:8080
#EXPOSE 8080
#
## Run the app
#ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]
#


# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY Ecommerencesite/*.csproj ./Ecommerencesite/
RUN dotnet restore
COPY Ecommerencesite/. ./Ecommerencesite/
WORKDIR /src/Ecommerencesite
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]
