#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Rz.DddDemo.Legacy.RouteProviderA/Rz.DddDemo.Legacy.RouteProviderA.csproj", "Rz.DddDemo.Legacy.RouteProviderA/"]
RUN dotnet restore "Rz.DddDemo.Legacy.RouteProviderA/Rz.DddDemo.Legacy.RouteProviderA.csproj"
COPY . .
WORKDIR "/src/Rz.DddDemo.Legacy.RouteProviderA"
RUN dotnet build "Rz.DddDemo.Legacy.RouteProviderA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rz.DddDemo.Legacy.RouteProviderA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rz.DddDemo.Legacy.RouteProviderA.dll"]