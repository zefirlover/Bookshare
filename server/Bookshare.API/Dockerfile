#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bookshare.API/Bookshare.API.csproj", "Bookshare.API/"]
COPY ["Bookshare.ApplicationServices/Bookshare.ApplicationServices.csproj", "Bookshare.ApplicationServices/"]
COPY ["Bookshare.DomainServices/Bookshare.DomainServices.csproj", "Bookshare.DomainServices/"]
COPY ["Bookshare.Domain/Bookshare.Domain.csproj", "Bookshare.Domain/"]
RUN dotnet restore "Bookshare.API/Bookshare.API.csproj"
COPY . .
WORKDIR "/src/Bookshare.API"
RUN dotnet build "Bookshare.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bookshare.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookshare.API.dll"]