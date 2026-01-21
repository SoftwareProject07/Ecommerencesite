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
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Sab kuch copy karein (kyuki humne Root Directory set kar di hai)
COPY . .

# Restore aur Publish karein
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Render default port
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Dhyan dein: file ka naam sahi ho
ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]