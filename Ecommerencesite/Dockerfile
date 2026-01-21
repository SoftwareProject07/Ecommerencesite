# 1. SDK image ka use karke build karein
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2. .csproj file copy karein aur restore karein
# Dhyan dein: Agar file folder ke andar hai toh path sahi likhein
COPY ["Ecommerencesite.csproj", "./"]
RUN dotnet restore "Ecommerencesite.csproj"

# 3. Baaki saara code copy karein aur build karein
COPY . .
RUN dotnet build "Ecommerencesite.csproj" -c Release -o /app/build

# 4. Publish karein
FROM build AS publish
RUN dotnet publish "Ecommerencesite.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 5. Runtime image taiyar karein
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Render ke liye port set karein
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]