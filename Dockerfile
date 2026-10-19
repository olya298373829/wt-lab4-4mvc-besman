FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем .csproj с учетом вложенной папки
COPY ["wt-lab4-4mvc-besman/wt-lab4-4mvc-besman.csproj", "wt-lab4-4mvc-besman/"]
RUN dotnet restore "wt-lab4-4mvc-besman/wt-lab4-4mvc-besman.csproj"

# Копируем исходники и переходим в папку проекта для сборки
COPY . .
WORKDIR "/src/wt-lab4-4mvc-besman"
RUN dotnet publish "wt-lab4-4mvc-besman.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "wt-lab4-4mvc-besman.dll"]