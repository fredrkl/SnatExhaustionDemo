FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app
COPY . .
RUN ["dotnet", "publish"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /app
COPY --from=build /app/bin/Debug/net5.0/publish/ .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "SnatExhaustionDemo.dll" ]