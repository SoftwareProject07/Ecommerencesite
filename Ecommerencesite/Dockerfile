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


# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Sabse pehle sari files copy karein
COPY . .

# Wildcard use karke publish karein taaki path ki error na aaye
RUN dotnet publish *.csproj -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Render ke liye default port set karein
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Dhyan dein: Agar file ka naam Ecommerencesite.dll hai toh wahi likhein
ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]