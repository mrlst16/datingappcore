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

ENV certPassword Matty30!

#RUN openssl genrsa -des3 -passout pass:${certPassword} -out server.key 2048
#RUN openssl rsa -passin pass:${certPassword} -in server.key -out server.key
#RUN openssl req -sha256 -new -key server.key -out server.csr -subj '/CN=localhost'
#RUN openssl x509 -req -sha256 -days 365 -in server.csr -signkey server.key -out server.crt
#RUN openssl pkcs12 -export -out cert.pfx -inkey server.key -in server.crt -certfile server.crt -passout pass:${certPassword}

ENV ASPNETCORE_URLS http://+:443

EXPOSE 80
EXPOSE 443
EXPOSE 3000

#RUN find -name "cert.pfx"

FROM build AS publish
RUN dotnet publish "DatingAppCore.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DatingAppCore.Api.dll"]