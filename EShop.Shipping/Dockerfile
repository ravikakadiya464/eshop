#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EShop.Shipping/EShop.Shipping.csproj", "EShop.Shipping/"]
COPY ["EShop.Infra.Repository/EShop.Infra.Repository.csproj", "EShop.Infra.Repository/"]
COPY ["EShop.Infra.Contract/EShop.Infra.Contract.csproj", "EShop.Infra.Contract/"]
COPY ["EShop.Infra.Domain/EShop.Infra.Domain.csproj", "EShop.Infra.Domain/"]
COPY ["EShop.Common/EShop.Common.csproj", "EShop.Common/"]
COPY ["EShop.Shipping.Core.Service/EShop.Shipping.Core.Service.csproj", "EShop.Shipping.Core.Service/"]
COPY ["EShop.Shipping.Core.Contract/EShop.Shipping.Core.Contract.csproj", "EShop.Shipping.Core.Contract/"]
COPY ["EShop.Core.Domain/EShop.Core.Domain.csproj", "EShop.Core.Domain/"]
RUN dotnet restore "EShop.Shipping/EShop.Shipping.csproj"
COPY . .
WORKDIR "/src/EShop.Shipping"
RUN dotnet build "EShop.Shipping.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.Shipping.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true \
    ServiceBusConnection='' \
    productSqlConnection=''