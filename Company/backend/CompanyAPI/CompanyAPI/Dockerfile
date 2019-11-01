FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CompanyAPI/CompanyAPI.csproj", "CompanyAPI/"]
COPY ["CompanyAPI.Repository/CompanyAPI.Repository.csproj", "CompanyAPI.Repository/"]
COPY ["CompanyAPI.Database/CompanyAPI.Database.csproj", "CompanyAPI.Database/"]
COPY ["CompanyAPI.Domain/CompanyAPI.Domain.csproj", "CompanyAPI.Domain/"]
COPY ["CompanyAPI.Shared/CompanyAPI.Shared.csproj", "CompanyAPI.Shared/"]
COPY ["CompanyAPI.Services/CompanyAPI.Services.csproj", "CompanyAPI.Services/"]
RUN dotnet restore "CompanyAPI/CompanyAPI.csproj"
COPY . .
WORKDIR "/src/CompanyAPI"
RUN dotnet build "CompanyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyAPI.dll"]