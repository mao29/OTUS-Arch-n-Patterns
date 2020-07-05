Приложение представляет собой консольную утилиту на .net core 3.1. Для запуска необходимо установить .Net Core SDK 3.1. Помимо самого приложения также реализованы модульные тесты, проверяющие корректность реализации алгоритмов сортировки и корректность записи в файл с разделителями.

### Диаграмма классов
![Диаграмма классов](/FactoryHomeWork/ClassDiagram1.png?raw=true)

Для запуска приложения необходимо
1. Перейти в папку FactoryHomeWork командой `cd FactoryHomeWork`
2. Запустить команду `dotnet run "SortingMethod" "SourceFilePath" "DestinationFilePath" "Separator"`
> Например `dotnet run Insertion in.txt out.txt Space` 

В результате будет произведена сборка и запуск проекта.

Доступные SortingMethod:
* Bubble
* Insertion
* Selection

Доступные Separator:
* Tab
* Space
* NewLine

Чтобы запустить тесты, необходимо выполнить команду
> dotnet test -v n

в корневой папке проекта.