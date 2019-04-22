FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DatingAppCore.Api.csproj", "./"]
RUN dotnet restore "./DatingAppCore.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DatingAppCore.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DatingAppCore.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DatingAppCore.Api.csproj"]