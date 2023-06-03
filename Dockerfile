#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mars.Promocao.Gerador.Codigo/Mars.Promocao.Gerador.Codigo/Mars.Promocao.Apresentacao.csproj", "Mars.Promocao.Gerador.Codigo/"]
COPY ["Mars.Promocao.Dominio/Mars.Promocao.Dominio.csproj", "Mars.Promocao.Dominio/"]
COPY ["Mars.Promocao.DTO/Mars.Promocao.DTO.csproj", "Mars.Promocao.DTO/"]
COPY ["Mars.Promocao.IoC/Mars.Promocao.IoC.csproj", "Mars.Promocao.IoC/"]
COPY ["Mars.Promocao.Servicos/Mars.Promocao.Servicos.csproj", "Mars.Promocao.Servicos/"]
RUN dotnet restore "Mars.Promocao.Gerador.Codigo/Mars.Promocao.Apresentacao.csproj"
COPY . .
WORKDIR "/src/Mars.Promocao.Gerador.Codigo/"
RUN dotnet build "Mars.Promocao.Apresentacao.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mars.Promocao.Apresentacao.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Mars.Promocao.Apresentacao.dll
#ENTRYPOINT ["dotnet", "Mars.Promocao.Apresentacao.dll"]