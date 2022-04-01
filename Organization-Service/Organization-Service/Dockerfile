FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Organization-Service/Organization-Service.csproj", "Organization-Service/"]
RUN dotnet restore "Organization-Service/Organization-Service.csproj"
COPY . .
WORKDIR "/src/Organization-Service"
RUN dotnet build "Organization-Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Organization-Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Organization-Service.dll"]
