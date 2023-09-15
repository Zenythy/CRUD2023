#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ControleAcesso/ControleAcesso.csproj", "ControleAcesso/"]
RUN dotnet restore "ControleAcesso/ControleAcesso.csproj"
COPY . .
WORKDIR "/src/ControleAcesso"
RUN dotnet build "ControleAcesso.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControleAcesso.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControleAcesso.dll"]