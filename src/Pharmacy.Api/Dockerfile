FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Pharmacy.Api/Pharmacy.Api.csproj", "Pharmacy.Api/"]
RUN dotnet restore "Pharmacy.Api/Pharmacy.Api.csproj"
COPY . .
WORKDIR "/src/Pharmacy.Api"
RUN dotnet build "Pharmacy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pharmacy.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pharmacy.Api.dll"]
