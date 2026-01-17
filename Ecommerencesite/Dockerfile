#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
#COPY *.sln .
#COPY Ecommerencesite/*.csproj Ecommerencesite/
#RUN dotnet restore
#
#COPY . .
#WORKDIR /src/Ecommerencesite
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



FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY EcommerceMedicineAPI/*.csproj EcommerceMedicineAPI/
RUN dotnet restore

COPY . .
WORKDIR /src/EcommerceMedicineAPI
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "EcommerceMedicineAPI.dll"]
