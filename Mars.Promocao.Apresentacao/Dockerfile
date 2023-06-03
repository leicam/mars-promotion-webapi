#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./*.sln ./

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done
RUN dotnet restore

COPY . ./
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Mars.Promocao.Apresentacao.dll

#COPY ["Mars.Promocao.Apresentacao.csproj", "Mars.Promocao.Apresentacao/"]
#E:\Projetos\Mars.Promocao.Api\Mars.Promocao.IoC\Mars.Promocao.IoC.csproj
#COPY ["../Mars.Promocao.IoC/Mars.Promocao.IoC.csproj", "Mars.Promocao.IoC/"]

#RUN dotnet restore "Mars.Promocao.Apresentacao/Mars.Promocao.Apresentacao.csproj"
#COPY . .
#WORKDIR "/src/Mars.Promocao.Apresentacao"
#RUN dotnet build "Mars.Promocao.Apresentacao.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Mars.Promocao.Apresentacao.csproj" -c Release -o /app/publish /p:UseAppHost=false

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Mars.Promocao.Apresentacao.dll"]