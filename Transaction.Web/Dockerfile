#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Transaction.Web/Transaction.Web.csproj", "Transaction.Web/"]
COPY ["Transaction.Core/Transaction.Core.csproj", "Transaction.Core/"]
COPY ["Transaction.Infrastructor/Transaction.Infrastructor.csproj", "Transaction.Infrastructor/"]
RUN dotnet restore "./Transaction.Web/Transaction.Web.csproj"
COPY . .
WORKDIR "/src/Transaction.Web"
RUN dotnet build "./Transaction.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Transaction.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transaction.Web.dll"]