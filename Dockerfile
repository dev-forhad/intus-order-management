# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published application files to the container
COPY --from=build /app/out ./

# Set the ASP.NET Core environment
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose the port used by the application
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "MyBlazorApp.Server.dll"]
