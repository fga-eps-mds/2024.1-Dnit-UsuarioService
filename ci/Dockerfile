FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY UsuarioService.sln ./
COPY app/app.csproj ./app/
COPY api/api.csproj ./api/
COPY auth/auth.csproj ./auth/
COPY test/test.csproj ./test/

RUN dotnet restore

COPY . ./

RUN dotnet build -c Release

RUN dotnet publish -c Release --no-restore -o build app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /app/build .
COPY --from=build /app/app/Migrations/Data/ /app/Migrations/Data/

CMD ["dotnet", "app.dll"]
