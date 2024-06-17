FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["File-It/FileServiceAPI/FileServiceAPI.csproj", "FileServiceAPI/"]
RUN dotnet restore "FileServiceAPI/FileServiceAPI.csproj"
COPY . .
WORKDIR "/src/File-It/FileServiceAPI"
RUN dotnet build "FileServiceAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "FileServiceAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileServiceAPI.dll"]
