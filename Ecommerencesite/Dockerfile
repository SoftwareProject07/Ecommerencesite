#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /app
#
## Sab kuch copy karein (alag se csproj copy karne ki jagah)
#COPY . .
#
## Restore aur Publish ek saath karein
#RUN dotnet publish "Ecommerencesite.csproj" -c Release -o /out
#
## Runtime stage
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
#WORKDIR /app
#COPY --from=build /out .
#
#ENV ASPNETCORE_URLS=http://+:10000
#EXPOSE 10000
#
#ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]


# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sari files copy karein
COPY . .

# Publish karein (Wildcard se .csproj khud dhund lega)
RUN dotnet publish *.csproj -c Release -o /app/publish

# 2. Runtime Stage
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
#WORKDIR /app
#COPY --from=build /app/publish .

# Render ka default port
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]