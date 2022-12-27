FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Cart/CartQueryAPI/CartQueryAPI.csproj", "CartQueryAPI/"]
RUN dotnet restore "Services/Cart/CartQueryAPI/CartQueryAPI.csproj"
COPY . .
WORKDIR "/src/CartQueryAPI"
RUN dotnet build "CartQueryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CartQueryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartQueryAPI.dll"]
