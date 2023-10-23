#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ["NuGet.Config", "."]
COPY ["EFSoft.Orders.Api/EFSoft.Orders.Api.csproj", "EFSoft.Orders.Api/"]
COPY ["EFSoft.Orders.Application/EFSoft.Orders.Application.csproj", "EFSoft.Orders.Application/"]
COPY ["EFSoft.Orders.Domain/EFSoft.Orders.Domain.csproj", "EFSoft.Orders.Domain/"]
COPY ["EFSoft.Orders.Infrastructure/EFSoft.Orders.Infrastructure.csproj", "EFSoft.Orders.Infrastructure/"]

ARG NUGET_PASSWORD
RUN apk add --update sed 
RUN sed -i "s|</configuration>|<packageSourceCredentials><emilfilip3><add key=\"Username\" value=\"emilfilip3\" /><add key=\"ClearTextPassword\" value=\"${NUGET_PASSWORD}\" /></emilfilip3></packageSourceCredentials></configuration>|" NuGet.Config

RUN dotnet restore "EFSoft.Orders.Api/EFSoft.Orders.Api.csproj" --configfile NuGet.Config

COPY . .
WORKDIR "/src/EFSoft.Orders.Api"
RUN dotnet build "EFSoft.Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.Orders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.Orders.Api.dll"]
