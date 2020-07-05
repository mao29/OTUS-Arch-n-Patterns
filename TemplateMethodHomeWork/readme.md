Приложение представляет собой консольную утилиту на .net core 3.1. Для запуска необходимо установить .Net Core SDK 3.1. Помимо самого приложения также реализованы модульные тесты, проверяющие корректность вызовов в шаблонном методе, а также корректность фабричного метода, создающего обработчики операций.

### Диаграмма классов
![Диаграмма классов](/TemplateMethodHomeWork/ClassDiagram1.png?raw=true)

Для запуска приложения необходимо
1. Перейти в папку TemplateMethodHomeWork командой `cd TemplateMethodHomeWork`
2. Запустить команду `dotnet run "Operation" "SourceFilePath" "DestinationFilePath"`
> Например `dotnet run Transponate in.txt out.txt` 

В результате будет произведена сборка и запуск проекта.

Доступные Operation:
* Transponate
* Determinant
* Add

Чтобы запустить тесты, необходимо выполнить команду
> dotnet test -v n

в корневой папке проекта.
