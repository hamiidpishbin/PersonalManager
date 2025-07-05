FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/DailyTasksManager/PM.DTM.API/PM.DTM.API.csproj", "src/Services/DailyTasksManager/PM.DTM.API/"]
COPY ["src/Services/DailyTasksManager/PM.DTM.Application/PM.DTM.Application.csproj", "src/Services/DailyTasksManager/PM.DTM.Application/"]
COPY ["src/Services/DailyTasksManager/PM.DTM.Infrastructure/PM.DTM.Infrastructure.csproj", "src/Services/DailyTasksManager/PM.DTM.Infrastructure/"]
COPY ["src/Services/DailyTasksManager/PM.DTM.Domain/PM.DTM.Domain.csproj", "src/Services/DailyTasksManager/PM.DTM.Domain/"]
COPY ["src/Common/PM.Common.Presentation/PM.Common.Presentation.csproj", "src/Common/PM.Common.Presentation/"]
COPY ["src/Common/PM.Common.Application/PM.Common.Application.csproj", "src/Common/PM.Common.Application/"]
COPY ["src/Common/PM.Common.Domain/PM.Common.Domain.csproj", "src/Common/PM.Common.Domain/"]
COPY ["src/Common/PM.Common.Infrastructure/PM.Common.Infrastructure.csproj", "src/Common/PM.Common.Infrastructure/"]
RUN dotnet restore "src/Services/DailyTasksManager/PM.DTM.API/PM.DTM.API.csproj"
COPY . .
WORKDIR "/src/src/Services/DailyTasksManager/PM.DTM.API"
RUN dotnet build "PM.DTM.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PM.DTM.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PM.DTM.API.dll"]
