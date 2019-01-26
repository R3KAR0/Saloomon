FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["LogService/LogService.csproj", "LogService/"]
RUN dotnet restore "LogService/LogService.csproj"
COPY . .
WORKDIR "/src/LogService"
RUN dotnet build "LogService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LogService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LogService.dll"]