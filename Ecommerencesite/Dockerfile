#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
#COPY . .
#RUN dotnet restore
#RUN dotnet publish -c Release -o /app/publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
#WORKDIR /app
#
#COPY --from=build /app/publish .
#
#ENV ASPNETCORE_URLS=http://0.0.0.0:8080
#EXPOSE 8080
#
#ENTRYPOINT ["dotnet", "Ecommerencesite.dll"]
#

# Step 1: Base image select karein (Node version 18-alpine lightweight hai)
FROM node:18-alpine

# Step 2: Container ke andar kaam karne ki jagah (working directory) set karein
WORKDIR /app

# Step 3: Pehle package files copy karein dependencies install karne ke liye
COPY package*.json ./

# Step 4: Dependencies install karein
RUN npm install

# Step 5: Baaki saara project code copy karein
COPY . .

# Step 6: Agar aapka project React hai toh build banayein (optional)
# RUN npm run build

# Step 7: Application jis port par chalegi (Render default 10000 use karta hai)
EXPOSE 10000

# Step 8: App start karne ki command
CMD ["npm", "start"]