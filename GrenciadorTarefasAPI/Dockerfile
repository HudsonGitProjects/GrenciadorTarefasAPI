#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GrenciadorTarefasAPI/GrenciadorTarefasAPI.csproj", "GrenciadorTarefasAPI/"]
RUN dotnet restore "./GrenciadorTarefasAPI/./GrenciadorTarefasAPI.csproj"
COPY . .
WORKDIR "/src/GrenciadorTarefasAPI"
RUN dotnet build "./GrenciadorTarefasAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GrenciadorTarefasAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrenciadorTarefasAPI.dll"]
# Usa imagem base oficial do .NET SDK 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Instala suporte a culturas
RUN apt-get update && apt-get install -y --no-install-recommends \
    locales \
    && rm -rf /var/lib/apt/lists/*

# Gera a cultura en_US.UTF-8
RUN echo "en_US.UTF-8 UTF-8" > /etc/locale.gen && locale-gen

# Define cultura global como en-US
ENV LANG=en_US.UTF-8 \
    LANGUAGE=en_US:en \
    LC_ALL=en_US.UTF-8

# Resto do Dockerfile
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build
CMD ["dotnet", "TaskManagerAPI.dll"]

