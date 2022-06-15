#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProjetoLoja.Api/ProjetoLoja.Api.csproj", "ProjetoLoja.Api/"]
COPY ["ProjetoLoja.Infra.IoC/ProjetoLoja.Infra.IoC.csproj", "ProjetoLoja.Infra.IoC/"]
COPY ["ProjetoLoja.Infra.Data/ProjetoLoja.Infra.Data.csproj", "ProjetoLoja.Infra.Data/"]
COPY ["ProjetoLoja.Domain/ProjetoLoja.Domain.csproj", "ProjetoLoja.Domain/"]
COPY ["ProjetoLoja.Application/ProjetoLoja.Application.csproj", "ProjetoLoja.Application/"]
RUN dotnet restore "ProjetoLoja.Api/ProjetoLoja.Api.csproj"
COPY . .
WORKDIR "/src/ProjetoLoja.Api"
RUN dotnet build "ProjetoLoja.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoLoja.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoLoja.Api.dll"]