FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM base AS final
WORKDIR /app
COPY /publish .
ENTRYPOINT ["dotnet", "App.API.dll"]
