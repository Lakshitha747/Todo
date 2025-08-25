# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution + all csproj files first to leverage Docker layer caching
COPY Todo.sln ./Todo.sln
COPY Todo.API/Todo.API.csproj ./Todo.API/Todo.API.csproj
COPY Todo.Contracts/Todo.Contracts.csproj ./Todo.Contracts/Todo.Contracts.csproj
COPY Todo.Domain/Todo.Domain.csproj ./Todo.Domain/Todo.Domain.csproj

# Restore
RUN dotnet restore ./Todo.sln

# Now copy the rest
COPY . .

# Publish only the API
RUN dotnet publish ./Todo.API/Todo.API.csproj -c Release -o /app/publish /p:UseAppHost=false

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080

# Let Kestrel listen on port 8080 (matches compose)
ENV ASPNETCORE_URLS=http://+:8080

# Database connection via env (overridden in compose)
ENV ConnectionStrings__Default=Host=postgres;Port=5432;Database=todo_db;Username=postgres;Password=postgres;Pooling=true

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "Todo.API.dll"]
