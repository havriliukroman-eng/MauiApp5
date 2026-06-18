# — ЕТАП 1: Збірка (Build) —
# Використовуємо образ SDK для компіляції та створення пакета
FROM ://microsoft.com AS build
WORKDIR /src

# Копіюємо файл проєкту та відновлюємо залежності
COPY ["MauiApp5.Web.csproj", "./"]
RUN dotnet restore "MauiApp5.Web.csproj"

# Копіюємо всі інші файли та робимо публікацію
COPY . .
RUN dotnet publish "MauiApp5.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# — ЕТАП 2: Фінальний образ (Runtime) —
# Використовуємо легкий образ ASP.NET Core для запуску (використовуйте runtime для Console)
FROM ://microsoft.com AS final
WORKDIR /app
EXPOSE 8080

# Копіюємо скомпільований додаток з етапу Build
COPY --from=build /app/publish .

# Вказуємо точку входу для запуску
ENTRYPOINT ["dotnet", "MauiApp5.dll"]
