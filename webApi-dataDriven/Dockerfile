FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["webApi-dataDriven/webApi-dataDriven.csproj", "webApi-dataDriven/"]
RUN dotnet restore "webApi-dataDriven/webApi-dataDriven.csproj"
COPY . .
WORKDIR "/src/webApi-dataDriven"
RUN dotnet build "webApi-dataDriven.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webApi-dataDriven.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webApi-dataDriven.dll"]
