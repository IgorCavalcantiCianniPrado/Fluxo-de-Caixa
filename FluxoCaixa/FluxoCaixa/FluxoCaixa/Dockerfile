FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FluxoCaixa/FluxoCaixa.csproj", "FluxoCaixa/"]
RUN dotnet restore "FluxoCaixa/FluxoCaixa.csproj"
COPY . .
WORKDIR "/src/FluxoCaixa"
RUN dotnet build "FluxoCaixa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluxoCaixa.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.dll"]