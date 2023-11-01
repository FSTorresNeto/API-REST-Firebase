FROM bitnami/dotnet-sdk:6.0.408-debian-11-r7 as build

WORKDIR /app

COPY . .

RUN apt-get update && apt-get -y upgrade

RUN dotnet build /app/Api/LixTec.Api.Application --output build/

FROM bitnami/aspnet-core:6.0.16-debian-11-r7

WORKDIR /app/build

ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:9014

COPY --from=build /app/build .

EXPOSE 9014
ENTRYPOINT ["dotnet", "LixTec.Api.Application.dll"]