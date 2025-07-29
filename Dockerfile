ARG DOTNET_VERSION=9.0
# Use the official .NET SDK image for build stage
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
# Set working directory
WORKDIR /src
# Copy project files first for better layer caching
COPY ["code/preinscription.csproj", "code/"]

# Restore NuGet packages
RUN dotnet restore "code/preinscription.csproj"
# Copy the rest of the application code
COPY . .
# Set working directory to project folder
WORKDIR "/src/code"
# Build the application
RUN dotnet build "preinscription.csproj" -c Release -o /app/build
# Publish stage
FROM build AS publish
RUN dotnet publish "preinscription.csproj" -c Release -o /app/publish --self-contained false --no-restore
# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
# Set working directory
WORKDIR /app
# Copy published app from publish stage (fixed from build to publish)
COPY --from=publish /app/publish .
# Create a non-root user
RUN addgroup --gid 1001 --system appgroup && \
adduser --uid 1001 --system --gid 1001 appuser
# Change ownership of the app directory
RUN chown -R appuser:appgroup /app
# Switch to non-root user
USER appuser
# Expose port
EXPOSE 8080
# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
# Entry point
ENTRYPOINT ["dotnet", "preinscription.dll"]