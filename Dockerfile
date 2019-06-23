FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DatingAppCore.Api/DatingAppCore.Api.csproj", "DatingAppCore.Api/"]
COPY ["DatingAppCore.BLL/DatingAppCore.BLL.csproj", "DatingAppCore.BLL/"]
COPY ["DatingAppCore.Repo/DatingAppCore.Repo.csproj", "DatingAppCore.Repo/"]
COPY ["DatingAppCore.Dto/DatingAppCore.Dto.csproj", "DatingAppCore.Dto/"]
COPY ["DatingAppCore.Interfaces/DatingAppCore.Interfaces.csproj", "DatingAppCore.Interfaces/"]
COPY ["DatingAppCore.Test/DatingAppCore.Test.csproj", "DatingAppCore.Test/"]
RUN dotnet restore "DatingAppCore.Api/DatingAppCore.Api.csproj"
COPY . .
WORKDIR "/src/DatingAppCore.Api"
RUN dotnet build "DatingAppCore.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DatingAppCore.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DatingAppCore.Api.dll"]