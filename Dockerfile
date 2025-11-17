# Use the official .NET 6 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set working directory
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "MyBackend.dll"]
