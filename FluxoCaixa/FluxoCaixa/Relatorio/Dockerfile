FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Relatorio/Relatorio.csproj", "Relatorio/"]
RUN dotnet restore "Relatorio/Relatorio.csproj"
COPY . .
WORKDIR "/src/Relatorio"
RUN dotnet build "Relatorio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Relatorio.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Relatorio.dll"]