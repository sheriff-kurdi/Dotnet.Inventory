FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS final
WORKDIR /build
COPY . .
ENTRYPOINT ["dotnet", "Kurdi.Inventory.Api.dll"]
