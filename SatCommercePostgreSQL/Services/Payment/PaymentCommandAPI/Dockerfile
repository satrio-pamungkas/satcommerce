FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Payment/PaymentCommandAPI/PaymentCommandAPI.csproj", "PaymentCommandAPI/"]
RUN dotnet restore "Services/Payment/PaymentCommandAPI/PaymentCommandAPI.csproj"
COPY . .
WORKDIR "/src/PaymentCommandAPI"
RUN dotnet build "PaymentCommandAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentCommandAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentCommandAPI.dll"]
