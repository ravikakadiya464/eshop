# eShop

## Introduction
The eShop application represents an online store that sells various physical products like t-shirts and coffee mugs. If you've bought anything online before, the experience of using the store should be relatively familiar.

## Requirements
Visual Studio https://visualstudio.microsoft.com/vs/community
OR
Visual Studio Code https://code.visualstudio.com/download

.Net SDK 6 https://dotnet.microsoft.com/en-us/download/dotnet/6.0

SQL Server https://www.microsoft.com/en-in/sql-server/sql-server-downloads

Docker https://docs.docker.com/desktop/install/windows-install

Service Bus in Azure

## Installation
Change the Connection string, Service bus connection string and Azure AD config in appsettings.json
Set Environment Variable for EShop.Shipping in Dockerfile

Run Migrations to create Database

```bash
Update-Database Initial_Migration
```

To Start the Docker Container of ApiGateway, Product Service, Shipping Service 
```bash
docker-compose up -d
```
Navigate to `http://localhost:5000/`.