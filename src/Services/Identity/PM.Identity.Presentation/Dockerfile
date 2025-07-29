FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Identity/PM.Identity.Presentation/PM.Identity.Presentation.csproj", "src/Services/Identity/PM.Identity.Presentation/"]
COPY ["src/Services/Identity/PM.Identity.Application/PM.Identity.Application.csproj", "src/Services/Identity/PM.Identity.Application/"]
COPY ["src/Services/Identity/PM.Identity.Infrastructure/PM.Identity.Infrastructure.csproj", "src/Services/Identity/PM.Identity.Infrastructure/"]
COPY ["src/Services/Identity/PM.Identity.Domain/PM.Identity.Domain.csproj", "src/Services/Identity/PM.Identity.Domain/"]
#COPY ["src/Common/PM.Common.Presentation/PM.Common.Presentation.csproj", "src/Common/PM.Common.Presentation/"]
COPY ["src/Common/PM.Common.Application/PM.Common.Application.csproj", "src/Common/PM.Common.Application/"]
COPY ["src/Common/PM.Common.Domain/PM.Common.Domain.csproj", "src/Common/PM.Common.Domain/"]
COPY ["src/Common/PM.Common.Infrastructure/PM.Common.Infrastructure.csproj", "src/Common/PM.Common.Infrastructure/"]
RUN dotnet restore "src/Services/Identity/PM.Identity.Presentation/PM.Identity.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/PM.Identity.Presentation"
RUN dotnet build "PM.Identity.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PM.Identity.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Docker
ENTRYPOINT ["dotnet", "PM.Identity.Presentation.dll"]
