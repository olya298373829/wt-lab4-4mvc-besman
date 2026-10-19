# 1. Используем SDK .NET 8 для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2. Копируем файл проекта и восстанавливаем зависимости
# УБЕДИТЕСЬ, ЧТО ИМЯ .csproj СОВПАДАЕТ С РЕАЛЬНЫМ ФАЙЛОМ!
COPY ["wt-lab4-4mvc-besman.csproj", "./"]
RUN dotnet restore "wt-lab4-4mvc-besman.csproj"

# 3. Копируем остальные файлы и собираем проект
COPY . .
RUN dotnet publish "wt-lab4-4mvc-besman.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:10000

# Укажите точное имя вашей итоговой dll (обычно совпадает с назв. csproj)
ENTRYPOINT ["dotnet", "wt-lab4-4mvc-besman.dll"]