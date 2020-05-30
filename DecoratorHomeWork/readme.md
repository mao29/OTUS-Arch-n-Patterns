Приложение представляет собой консольную утилиту на .net core 3.1. Помимо самого приложения также реализованы модульные тесты, проверяющие корректность реализации алгоритмов сортировки.

Для сборки необходимо установить .Net Core SDK 3.1 и выполнить в терминале команду
> dotnet build

В результате будет произведена сборка проекта и в папке `./DecoratorHomeWork/bin/Debug/netcoreapp3.1` появится файл `DecoratorHomeWork.dll`. 
Запустить его можно командой
> dotnet DecoratorHomeWork.dll "SortingMethod" "SourceFilePath" "DestinationFilePath"

перейдя в указанную выше папку.

Доступные SortingMethod:
* Bubble
* Insertion
* Selection

Чтобы запустить тесты, необходимо выполнить команду
> dotnet test -v n

в корневой папке проекта.