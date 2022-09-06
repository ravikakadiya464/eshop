# eShop

## Introduction
The eShop application represents an online store that sells various physical products like t-shirts and coffee mugs. If you've bought anything online before, the experience of using the store should be relatively familiar.

## Requirements
Visual Studio

.Net SDK 6

SQL Server

Docker

Service Bus in Azure

## Installatio
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