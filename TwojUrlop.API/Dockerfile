#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TwojUrlop.API/TwojUrlop.API.csproj", "TwojUrlop.API/"]
COPY ["TwojUrlop.Common/TwojUrlop.Common.csproj", "TwojUrlop.Common/"]
COPY ["TwojUrlop.DependencyInjection/TwojUrlop.DependencyInjection.csproj", "TwojUrlop.DependencyInjection/"]
COPY ["TwojUrlop.DataAccess/TwojUrlop.DataAccess.csproj", "TwojUrlop.DataAccess/"]
COPY ["TwojUrlop.DomainModel/TwojUrlop.DomainModel.csproj", "TwojUrlop.DomainModel/"]
COPY ["TwojUrlop.Domain/TwojUrlop.Domain.csproj", "TwojUrlop.Domain/"]
RUN dotnet restore "TwojUrlop.API/TwojUrlop.API.csproj"
COPY . .
WORKDIR "/src/TwojUrlop.API"
RUN dotnet build "TwojUrlop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwojUrlop.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwojUrlop.API.dll"]
