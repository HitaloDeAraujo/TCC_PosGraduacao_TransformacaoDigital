#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SIGO.GestaoNormas.API.csproj", "src/Modulos/GestaoNormas/SIGO.GestaoNormas.API/"]
COPY ["SIGO.GestaoNormas.Service.csproj", "src/Modulos/GestaoNormas/SIGO.GestaoNormas.Service/"]
COPY ["SIGO.GestaoNormas.Domain.csproj", "src/Modulos/GestaoNormas/SIGO.GestaoNormas.Domain/"]
COPY ["SIGO.Domain.csproj", "src/Modulos/CrossCutting/SIGO.Domain/"]
COPY ["SIGO.Bus.csproj", "src/Modulos/CrossCutting/SIGO.Bus/"]
COPY ["SIGO.Utils.csproj", "src/Modulos/CrossCutting/SIGO.Utils/"]
COPY ["SIGO.GestaoNormas.Infra.csproj", "src/Modulos/GestaoNormas/SIGO.GestaoNormas.Infra/"]
COPY ["SIGO.Infra.csproj", "src/Modulos/CrossCutting/SIGO.Infra/"]
RUN dotnet restore "src/Modulos/GestaoNormas/SIGO.GestaoNormas.API/SIGO.GestaoNormas.API.csproj"
COPY . .
WORKDIR "/src/src/Modulos/GestaoNormas/SIGO.GestaoNormas.API"
RUN dotnet build "SIGO.GestaoNormas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGO.GestaoNormas.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.GestaoNormas.API.dll"]