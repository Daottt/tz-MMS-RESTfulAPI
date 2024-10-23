
# Manufacturing Management System
## Зависимости
* .NET6
* PostgreSQL
## Установка
1. Клонируем репозиторий
    ```bash
    git clone https://github.com/Daottt/tz-MMS-RESTfulAPI.git
    cd tz-MMS-RESTfulAPI
    ```
2. Настраиваем подключение к базе данных
    - Файл конфигураций находится в \api\appsettings.Development.json
        ```json
        "ConnectionStrings": {
            "db": "Server=localhost;Database=db;Port=5432;User Id=postgres; Password=password"
        }
        ```
3. Восстанавливаем пакеты Nuget
    ```bash
    dotnet restore
    ```
4. Применяем миграции
	```bash
	dotnet ef database update --project data --startup-project api
	```
	- если dotnet ef не установлен
		```bash
		dotnet tool install --global dotnet-ef --version 6.*
		```
5. Запускаем приложение
	```bash
	dotnet run --project api
	```
### Аутентификация
Api использует Jwt для аутентификация. Получить токен можно по эндпойнту ```POST/api/login```  
передав эти параметры: 
```json
{
"login": "user",
"password": "password"
}
```
### Тесты
Для запуска тестов
```bash
dotnet test
```
