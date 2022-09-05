#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EShop.Product/EShop.Product.csproj", "EShop.Product/"]
COPY ["EShop.Product.Core.Service/EShop.Product.Core.Service.csproj", "EShop.Product.Core.Service/"]
COPY ["EShop.Core.Domain/EShop.Core.Domain.csproj", "EShop.Core.Domain/"]
COPY ["EShop.Product.Core.Contract/EShop.Product.Core.Contract.csproj", "EShop.Product.Core.Contract/"]
COPY ["EShop.Product.Core.Domain/EShop.Product.Core.Domain.csproj", "EShop.Product.Core.Domain/"]
COPY ["EShop.Common/EShop.Common.csproj", "EShop.Common/"]
COPY ["EShop.Infra.Contract/EShop.Infra.Contract.csproj", "EShop.Infra.Contract/"]
COPY ["EShop.Infra.Domain/EShop.Infra.Domain.csproj", "EShop.Infra.Domain/"]
COPY ["EShop.Infra.Repository/EShop.Infra.Repository.csproj", "EShop.Infra.Repository/"]
RUN dotnet restore "EShop.Product/EShop.Product.csproj"
COPY . .
WORKDIR "/src/EShop.Product"
RUN dotnet build "EShop.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.Product.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.Product.dll"]