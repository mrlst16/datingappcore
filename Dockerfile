FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

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

ENV ASPNETCORE_URLS=https://+:443;http://+:80;https://+:5001

EXPOSE 80
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM build AS publish
RUN dotnet publish "DatingAppCore.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app

COPY ["DatingAppCore.Api/bundle.pfx", "bundle.pfx"]

RUN find -name "bundle.pfx"
RUN ls

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DatingAppCore.Api.dll", "--urls", "http://*:5000;https://*:5001"]