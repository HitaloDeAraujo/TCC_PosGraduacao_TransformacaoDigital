#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.API/SIGO.AssessoriasConsultorias.API.csproj", "src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.API/"]
COPY ["src/Modulos/CrossCutting/SIGO.Bus/SIGO.Bus.csproj", "src/Modulos/CrossCutting/SIGO.Bus/"]
COPY ["src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.Service/SIGO.AssessoriasConsultorias.Service.csproj", "src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.Service/"]
COPY ["src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.Domain/SIGO.AssessoriasConsultorias.Domain.csproj", "src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.Domain/"]
COPY ["src/Modulos/CrossCutting/SIGO.Domain/SIGO.Domain.csproj", "src/Modulos/CrossCutting/SIGO.Domain/"]
COPY ["src/Modulos/CrossCutting/SIGO.Utils/SIGO.Utils.csproj", "src/Modulos/CrossCutting/SIGO.Utils/"]
COPY ["src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.Infra/SIGO.AssessoriasConsultorias.Infra.csproj", "src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.Infra/"]
COPY ["src/Modulos/CrossCutting/SIGO.Infra/SIGO.Infra.csproj", "src/Modulos/CrossCutting/SIGO.Infra/"]
RUN dotnet restore "src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.API/SIGO.AssessoriasConsultorias.API.csproj"
COPY . .
WORKDIR "/src/src/Modulos/AssessoriasConsultorias/SIGO.AssessoriasConsultorias.API"
RUN dotnet build "SIGO.AssessoriasConsultorias.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGO.AssessoriasConsultorias.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.AssessoriasConsultorias.API.dll"]