Решалась задача разработки многопоточного вычислителя произведения двух квадратных матриц.

В рамках решения задачи был разработан класс `ThreadedMatrixMultiplier`, который в ходе вычисления произведения матриц управляет пулом потоков заданного размера, обеспечивая, что в каждый момент времени вычисление производится потоками-вычислителями в количестве, не превышающем заданный размер. Если при переходе к вычислению очередного элемента произведения все потоки-вычислители оказываются заняты, основной поток встает в ожидание первого освободившегося вычислителя.

Приложение реализовано в виде консольной утилиты на .Net Core 3.1. Перед запуском требуется установить .Net Core SDK 3.1.

Для запуска утилиты необходимо осуществить команды
```bat
cd MatrixMultiplier
dotnet run
```

При запуске утилита вычитывает исходные данные из файла `in.txt`. Ожидаемый формат данных:
    
    n
    A11 A12 ... A1n
    A21 A22 ... A2n
    ...
    An1 An2 ... Ann
    B11 B12 ... B1n
    B21 B22 ... B2n
    ...
    Bn1 Bn2 ... Bnn
    p

где n - размер матриц, Aij, Bij - элементы матриц, p - количество потоков для вычисления.

> Утилита не проверяет корректность входных данных, поэтому может упасть, если ввести неправильное количество элементов матриц.

Результат вычисления записывается в файл `out.txt` в формате

    Elapsed <время вычисления> ms.
    C11 C22 ... C1n
    C21 C22 ... C2n
    ...
    Cn1 Cn2 ... Cnn

Лог вычисления, содержащий информацию о том, какой поток использовался для вычисления какого элемента матрицы-произведения, записывается после выполнения вычислений в файл `log.txt`.

Логгер реализован в виде синглтона с методом записи сообщения в лог и методом принудительного сброса всех еще не записавшихся сообщений в файловую систему.

### Диаграмма классов
![Диаграмма классов](/MatrixMultiplierSingleton/ClassDiagram1.png?raw=true)