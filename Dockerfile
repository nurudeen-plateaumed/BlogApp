FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /BlogApp

COPY ./BlogApp/*.csproj .

RUN dotnet restore

COPY ../ .

RUN dotnet publish BlogApp.sln -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY --from=build /app .


ENTRYPOINT ["dotnet", "BlogApp.dll"]
