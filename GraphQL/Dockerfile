FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet build -c Release -o /app
RUN dotnet publish  -c Release -o /app


###############################################################

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS prod

WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://*:4040
EXPOSE 4040
ENTRYPOINT ["dotnet", "GraphQl.dll"]