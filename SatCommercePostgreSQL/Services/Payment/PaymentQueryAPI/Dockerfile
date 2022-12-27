FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Payment/PaymentQueryAPI/PaymentQueryAPI.csproj", "PaymentQueryAPI/"]
RUN dotnet restore "Services/Payment/PaymentQueryAPI/PaymentQueryAPI.csproj"
COPY . .
WORKDIR "/src/PaymentQueryAPI"
RUN dotnet build "PaymentQueryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentQueryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentQueryAPI.dll"]
