FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Life-Balance.WebApp/Life-Balance.WebApp.csproj", "src/Life-Balance.WebApp/"]
COPY ["src/Life-Balance.Commin/Life-Balance.Common.csproj", "src/Life-Balance.Commin/"]
COPY ["src/Life-Balance.BLL/Life-Balance.BLL.csproj", "src/Life-Balance.BLL/"]
COPY ["src/Life-Balance.DAL/Life-Balance.DAL.csproj", "src/Life-Balance.DAL/"]
RUN dotnet restore "src/Life-Balance.WebApp/Life-Balance.WebApp.csproj"
COPY . .
WORKDIR "/src/src/Life-Balance.WebApp"
RUN dotnet build "Life-Balance.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Life-Balance.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Life-Balance.WepApp.dll