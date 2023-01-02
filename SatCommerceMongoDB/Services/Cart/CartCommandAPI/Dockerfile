FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Cart/CartCommandAPI/CartCommandAPI.csproj", "CartCommandAPI/"]
RUN dotnet restore "Services/Cart/CartCommandAPI/CartCommandAPI.csproj"
COPY . .
WORKDIR "/src/CartCommandAPI"
RUN dotnet build "CartCommandAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CartCommandAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartCommandAPI.dll"]
