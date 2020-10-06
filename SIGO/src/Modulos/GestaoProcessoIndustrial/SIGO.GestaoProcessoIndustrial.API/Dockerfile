#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.API/SIGO.GestaoProcessoIndustrial.API.csproj", "src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.API/"]
COPY ["src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.Domain/SIGO.GestaoProcessoIndustrial.Domain.csproj", "src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.Domain/"]
COPY ["src/Modulos/CrossCutting/SIGO.Domain/SIGO.Domain.csproj", "src/Modulos/CrossCutting/SIGO.Domain/"]
COPY ["src/Modulos/CrossCutting/SIGO.Bus/SIGO.Bus.csproj", "src/Modulos/CrossCutting/SIGO.Bus/"]
COPY ["src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.Service/SIGO.GestaoProcessoIndustrial.Service.csproj", "src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.Service/"]
COPY ["src/Modulos/CrossCutting/SIGO.Utils/SIGO.Utils.csproj", "src/Modulos/CrossCutting/SIGO.Utils/"]
COPY ["src/Simuladores/SIGO.Simuladores.AD/SIGO.Simuladores.AD.csproj", "src/Simuladores/SIGO.Simuladores.AD/"]
COPY ["src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.Infra/SIGO.GestaoProcessoIndustrial.Infra.csproj", "src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.Infra/"]
COPY ["src/Modulos/CrossCutting/SIGO.Infra/SIGO.Infra.csproj", "src/Modulos/CrossCutting/SIGO.Infra/"]
RUN dotnet restore "src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.API/SIGO.GestaoProcessoIndustrial.API.csproj"
COPY . .
WORKDIR "/src/src/Modulos/GestaoProcessoIndustrial/SIGO.GestaoProcessoIndustrial.API"
RUN dotnet build "SIGO.GestaoProcessoIndustrial.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGO.GestaoProcessoIndustrial.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.GestaoProcessoIndustrial.API.dll"]