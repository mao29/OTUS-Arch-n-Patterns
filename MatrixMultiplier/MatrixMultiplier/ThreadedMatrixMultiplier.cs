using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MatrixMultiplier
{
    /// <summary>
    /// Класс для перемножения матриц в несколько потоков.
    /// </summary>
    public class ThreadedMatrixMultiplier
    {
        /// <summary>
        /// Пул потоков-вычислителей.
        /// </summary>
        private Thread[] _threadPool;

        /// <summary>
        /// Очередь номеров незанятых потоков-вычислителей в пуле потоков.
        /// </summary>
        private Queue<int> _freeThreadQueue;

        /// <summary>
        /// Событие освобождения первого потока-вычислителя после момента, когда все потоки заняты.
        /// </summary>
        private AutoResetEvent _threadFreedEvent;

        /// <summary>
        /// Генератор случайных задержек потоков-вычислителей.
        /// </summary>
        private Random _threadSleepTimeGenerator;

        /// <summary>
        /// Объект для логирования вычислений.
        /// </summary>
        private ILog _calculationLog;

        /// <summary>
        /// Создать класс для перемножения матриц в несколько потоков.
        /// </summary>
        /// <param name="threadCount">Количество потоков, которые можно использовать одновременно.</param>
        public ThreadedMatrixMultiplier(int threadCount, ILog log)
        {
            if (threadCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(threadCount));
            }

            _threadPool = new Thread[threadCount];
            _freeThreadQueue = new Queue<int>(Enumerable.Range(0, threadCount));
            _threadFreedEvent = new AutoResetEvent(false);
            _threadSleepTimeGenerator = new Random();
            _calculationLog = log ?? new NullLog();
        }

        /// <summary>
        /// Вычислить произведение матриц.
        /// </summary>
        /// <param name="matrixSize">Размер матриц множителей.</param>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns>Матрица-произведение.</returns>
        public int[][] MultiplyMatrices(int matrixSize, int[][] matrix1, int[][] matrix2)
        {
            var matrixResult = PrepareResultMatrix(matrixSize);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    int iCopy = i;
                    int jCopy = j;
                    int freeThreadIndex = -1;
                    bool freeThreadExists = false;

                    // попытаемся получить номер свободного потока-вычислителя из пула
                    lock (_freeThreadQueue)
                    {
                        freeThreadExists = _freeThreadQueue.TryDequeue(out freeThreadIndex);

                        if (!freeThreadExists)
                        {
                            // если все потоки-вычислители заняты, взведем событие 
                            // для ожидания освобождения какого-либо потока-вычислителя
                            _threadFreedEvent.Reset();
                        }
                    }

                    if (!freeThreadExists)
                    {
                        // если свободных потоков-вычислителей нет,
                        // встанем в ожидание освобождения какого-либо потока-вычислителя
                        _threadFreedEvent.WaitOne();

                        lock (_freeThreadQueue)
                        {
                            freeThreadIndex = _freeThreadQueue.Dequeue();
                        }
                    }

                    // сгенерируем время искусственной задержки потока в пределах 50мс
                    int threadSleepTime = _threadSleepTimeGenerator.Next(50);

                    _threadPool[freeThreadIndex] = new Thread(() =>
                    {
                        _calculationLog.Log($"Thread {freeThreadIndex} calculating element [{iCopy}][{jCopy}]");

                        Thread.Sleep(threadSleepTime);

                        for (int k = 0; k < matrixSize; k++)
                        {
                            matrixResult[iCopy][jCopy] += matrix1[iCopy][k] * matrix2[k][jCopy];
                        }

                        // после вычисления сообщим главному потоку, 
                        // что процесс пула с номером freeThreadIndex освободился
                        lock (_freeThreadQueue)
                        {
                            _freeThreadQueue.Enqueue(freeThreadIndex);

                            _threadFreedEvent.Set();
                        }
                    });

                    _threadPool[freeThreadIndex].Start();
                }
            }

            WaitForAllThreads();

            return matrixResult;
        }

        /// <summary>
        /// Метод для создания пустой матрицы заданного размера.
        /// </summary>
        /// <param name="matrixSize">Размер матрицы.</param>
        /// <returns>Пустая матрица заданного размера.</returns>
        private int[][] PrepareResultMatrix(int matrixSize)
        {
            var matrixResult = new int[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
            {
                matrixResult[i] = new int[matrixSize];
            }
            return matrixResult;
        }

        /// <summary>
        /// Дождаться завершения всех процессов-вычислителей.
        /// </summary>
        private void WaitForAllThreads()
        {
            int threadsInProgress = _threadPool.Length;

            while (threadsInProgress > 0)
            {
                bool threadFinished = false;

                // проверим есть ли потоки в очереди освободившихся потоков-вычислителей
                lock (_freeThreadQueue)
                {
                    threadFinished = _freeThreadQueue.TryDequeue(out _);

                    if (!threadFinished)
                    {
                        // если все оставшиеся потоки-вычислители заняты, взведем событие 
                        // для ожидания освобождения какого-либо потока-вычислителя
                        _threadFreedEvent.Reset();
                    }
                }

                if (!threadFinished)
                {
                    _threadFreedEvent.WaitOne();

                    lock (_freeThreadQueue)
                    {
                        _freeThreadQueue.Dequeue();
                    }
                }

                threadsInProgress--;
            }
        }
    }
}
